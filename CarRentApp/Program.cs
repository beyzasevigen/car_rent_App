using CarRentApp.Commands.Requests;
using CarRentApp.Commands.Requests.CreateCar;
using CarRentApp.Commands.Requests.CreateCompany;
using CarRentApp.Commands.Requests.CreateCustomer;
using CarRentApp.Commands.Requests.RentCar;
using CarRentApp.Commands.Requests.ReturnCar;
using CarRentApp.Models;
using CarRentApp.Models.CarRentApp.Models;
using CarRentApp.Services;
using CarRentApp.Services.Commands; 
using CarRentApp.Services.Queries;
using CarRentApp.Shared;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver;
using System;

class Program
{
    public static async Task Main(string[] args)
    {
        //var userService = new UserService();

        var services = new ServiceCollection();

        // Mongo setup 
        services.AddSingleton<IMongoClient>(new MongoClient("mongodb://localhost:27017"));
        services.AddSingleton(sp => sp.GetRequiredService<IMongoClient>().GetDatabase("CarRentDB"));

        // MediatR setup
        services.AddMediatR(typeof(Program));

        // Servisler
        services.AddTransient<CreateCarService>();
        services.AddTransient<CreateCompanyService>();
        services.AddTransient<CreateCustomerService>();
        services.AddTransient<RentCarService>();
        services.AddTransient<ReturnCarService>();
        services.AddTransient<GetAllCarsService>();
        services.AddTransient<GetAvailableCarsService>();
        services.AddTransient<GetCarByIdService>();
        services.AddTransient<GetAllCompaniesService>();
        services.AddTransient<GetAllContractsService>();
        services.AddSingleton<UserService>();

        var provider = services.BuildServiceProvider();

        var userService = provider.GetRequiredService<UserService>();
        var createCarService = provider.GetRequiredService<CreateCarService>();
        var createCompanyService = provider.GetRequiredService<CreateCompanyService>();
        var createCustomerService = provider.GetRequiredService<CreateCustomerService>();
        var getAllCarsService = provider.GetRequiredService<GetAllCarsService>();
        var getCarByIdService = provider.GetRequiredService<GetCarByIdService>();
        var getAvailableCarsService = provider.GetRequiredService<GetAvailableCarsService>();
        var rentCarService = provider.GetRequiredService<RentCarService>();
        var returnCarService = provider.GetRequiredService<ReturnCarService>();
        var getAllCompaniesService = provider.GetRequiredService<GetAllCompaniesService>();
        var getAllContractsService = provider.GetRequiredService<GetAllContractsService>();


        User? loggedUser = null;

        while (loggedUser == null)
        {
            Console.Clear();
            Console.WriteLine("1) Giriş Yap");
            Console.WriteLine("2) Kayıt Ol");

            int choice = ConsoleHelper.GetChoice(1, 2);

            if (choice == 1)
            {
                Console.Write("Kullanıcı Adı: ");
                string username = Console.ReadLine()!;
                Console.Write("Şifre: ");
                string password = Console.ReadLine()!;

                loggedUser = userService.Login(username, password);

                if (loggedUser == null)
                {
                    Console.WriteLine("Kullanıcı adı veya şifre hatalı.");
                    ConsoleHelper.Pause();
                }
            }
            else if (choice == 2)
            {
                Console.Write("Kullanıcı id: ");
                string usernameID = Console.ReadLine()!;
                Console.Write("Kullanıcı Adı: ");
                string username = Console.ReadLine()!;
                Console.Write("Şifre: ");
                string password = Console.ReadLine()!;
                Console.Write("Ad Soyad: ");
                string fullName = Console.ReadLine()!;
                Console.Write("Telefon: ");
                string phone = Console.ReadLine()!;
                Console.Write("Email: ");
                string email = Console.ReadLine()!;

                // UserService tarafında kayıt işlemi
                bool registered = userService.Register(username, password);

                if (registered)
                {
                    // MongoDB tarafında Customer kaydı
                    var createCustomerRequest = new CreateCustomerRequest
                    {
                        CustomerId = usernameID,
                        Fullname = fullName,
                        Phone = phone,
                        Email = email,
                        Username = username,
                        Password = password
                    };

                    var result = await createCustomerService.CreateCustomerAsync(createCustomerRequest);

                    if (result.Success)
                        Console.WriteLine("Kayıt başarılı, giriş yapabilirsiniz ve müşteri bilgisi eklendi.");
                    else
                        Console.WriteLine($"Kullanıcı eklendi ama müşteri eklenemedi: {result.Message}");
                }
                else
                {
                    Console.WriteLine("Bu kullanıcı adı zaten var.");
                }

                ConsoleHelper.Pause();
            }

        }

        // role göre menü göster
        if (loggedUser.Role == UserRole.Admin)
        {
            await AdminMenu(loggedUser, createCarService, createCompanyService, createCustomerService, rentCarService, getAllCarsService, getAllCompaniesService, getAllContractsService, getAvailableCarsService, getCarByIdService);
        }
        else
        {
            await CustomerMenu(loggedUser, rentCarService, returnCarService);
        }
    }

    public static async Task AdminMenu(User admin, CreateCarService createCarService, CreateCompanyService createCompanyService, CreateCustomerService createCustomerService, RentCarService rentCarService, GetAllCarsService getAllCarsService, GetAllCompaniesService getAllCompaniesService, GetAllContractsService getAllContractsService, GetAvailableCarsService getAvailableCarsService, GetCarByIdService getCarByIdService)
    {
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine($"Admin Girişi: {admin.Username}");
            Console.WriteLine("1) İşlem Yap");
            Console.WriteLine("2) Listele");
            Console.WriteLine("3) Çıkış");

            int choice = ConsoleHelper.GetChoice(1, 3);

            if (choice == 1)
            {
                await AdminOperationMenu(createCarService, createCompanyService, createCustomerService, rentCarService);
            }
            else if (choice == 2)
            {
                await AdminListMenu(getAllCarsService, getAllCompaniesService, getAllContractsService, getAvailableCarsService, getCarByIdService);
            }
            else
            {
                return;
            }
        }
    }

    static async Task AdminOperationMenu(CreateCarService createCarService, CreateCompanyService createCompanyService, CreateCustomerService createCustomerService, RentCarService rentCarService)
    {
        Console.Clear();
        Console.WriteLine("1) Araba Ekle");
        Console.WriteLine("2) Şirket ekle");
        Console.WriteLine("3) Müşteri Ekle");
        Console.WriteLine("4) Arabayı Kirala");
        Console.WriteLine("5) Geri");

        int choice = ConsoleHelper.GetChoice(1, 5);

        switch (choice)
        {
            case 1:
                Console.Write("araba id: ");
                string carcId = Console.ReadLine()!;
                Console.Write("Marka: ");
                string brand = Console.ReadLine()!;
                Console.Write("Model: ");
                string model = Console.ReadLine()!;
                Console.Write("Vites Tipi: ");
                string gearType = Console.ReadLine()!;
                Console.Write("Yakıt Tipi: ");
                string fuelType = Console.ReadLine()!;
                Console.Write("Şirket ID: ");
                string carCompanyId = Console.ReadLine()!;

                var requestCar = new CreateCarRequest
                {
                    CarcId = carcId,
                    Brand = brand,
                    Model = model,
                    GearType = gearType,
                    FuelType = fuelType,
                    IsAvailable = true,
                    CompanyId = carCompanyId
                };

                var resultCar = await createCarService.CreateCarAsync(requestCar);
                Console.WriteLine(resultCar.Success ? "Araba başarıyla eklendi." : $"Hata: {resultCar.Message}");
                Console.ReadKey();
                break;
            case 2:
                Console.Write("company id: ");
                string compId = Console.ReadLine()!;
                Console.Write("Name: ");
                string name = Console.ReadLine()!;
                Console.Write("Address: ");
                string address = Console.ReadLine()!;
                Console.Write("Phone: ");
                string companyPhone = Console.ReadLine()!;

                var requestCompany = new CreateCompanyRequest
                {
                    CompId = compId,
                    Name = name,
                    Address = address,
                    Phone = companyPhone,
                };

                var resultCompany = await createCompanyService.CreateCompanyAsync(requestCompany);
                Console.WriteLine(resultCompany.Success ? "şirket başarıyla eklendi." : $"Hata: {resultCompany.Message}");
                Console.ReadKey();
                break;
            case 3:
                Console.Write("customer id: ");
                string custId = Console.ReadLine()!;
                Console.Write("customer username: ");
                string custUserrname = Console.ReadLine()!;
                Console.Write("customer passord: ");
                string custPassword = Console.ReadLine()!;
                Console.Write("ad soyad: ");
                string fullName = Console.ReadLine()!;
                Console.Write("Phone: ");
                string customerPhone = Console.ReadLine()!;
                Console.Write("Email: ");
                string email = Console.ReadLine()!;


                var requestCustomer = new CreateCustomerRequest
                {
                    CustomerId = custId,
                    Username = custUserrname,
                    Password = custPassword,
                    Fullname = fullName,
                    Phone = customerPhone,
                    Email = email,
                };

                var resultCustomer = await createCustomerService.CreateCustomerAsync(requestCustomer);
                Console.WriteLine(resultCustomer.Success ? "Müşteri başarıyla eklendi." : $"Hata: {resultCustomer.Message}");
                Console.ReadKey();
                break;
            case 4:
                Console.Write("sözlesme id :( : ");
                string contractId = Console.ReadLine()!;
                Console.Write("Kiralayacağınız Araba ID: ");
                string carId = Console.ReadLine()!;
                Console.Write("Şirket ID: ");
                string rentCompanyId = Console.ReadLine()!;
                Console.Write("Müşteri ID: ");
                String customerId = Console.ReadLine()!;
                Console.Write("Kiralama Tarihi (yyyy-MM-dd): ");
                DateTime rentDate = DateTime.Parse(Console.ReadLine()!);
                Console.Write("İade Tarihi (yyyy-MM-dd): ");
                DateTime returnDate = DateTime.Parse(Console.ReadLine()!);

                var rentRequest = new RentCarRequest
                {
                    ContractId = contractId,
                    CarId = carId,
                    CompanyId = rentCompanyId,
                    CustomerId = customerId,
                    RentDate = rentDate,
                    ReturnDate = returnDate
                };

                var rentResult = await rentCarService.RentCarAsync(rentRequest);
                Console.WriteLine(rentResult.Success ? "Kiralama başarılı." : $"Hata: {rentResult.Message}");
                Console.ReadKey();
                break;
            case 5:

                return;
        }

        ConsoleHelper.Pause();
    }

    static async Task AdminListMenu(GetAllCarsService getAllCarsService, GetAllCompaniesService getAllCompaniesService, GetAllContractsService getAllContractsService, GetAvailableCarsService getAvailableCarsService, GetCarByIdService getCarByIdService)
    {
        Console.Clear();
        Console.WriteLine("1) Tüm Arabaları Listele");
        Console.WriteLine("2) Tüm Şirketleri Listele");
        Console.WriteLine("3) Tüm Kontratları Listele");
        Console.WriteLine("4) Müsait Arabaları Listele");
        Console.WriteLine("5) Araba Ara (ID ile)");
        Console.WriteLine("6) Geri");

        int choice = ConsoleHelper.GetChoice(1, 6);

        switch (choice)
        {
            case 1:
                var allCars = await getAllCarsService.GetAllCarsAsync();
                if (allCars.Success && allCars.Data is List<Car> cars)
                {
                    foreach (var searchCar in cars)
                    {
                        Console.WriteLine($"{searchCar.Id} - {searchCar.Brand} {searchCar.Model} ({searchCar.FuelType}, {searchCar.GearType}) | Müsait: {searchCar.IsAvailable}");
                    }
                }
                else
                {
                    Console.WriteLine(allCars.Message);
                }
                Console.ReadKey();
                break;
            case 2:
                var companies = await getAllCompaniesService.GetAllCompaniesAsync();
                if (companies.Success && companies.Data is List<Company> comps)
                {
                    foreach (var c in comps)
                    {
                        Console.WriteLine($"{c.Id} - {c.Name}");
                    }
                }
                else
                {
                    Console.WriteLine(companies.Message);
                }
                Console.ReadKey();
                break;
            case 3:
                var contracts = await getAllContractsService.GetAllContractsAsync();
                if (contracts.Success && contracts.Data is List<Contract> cons)
                {
                    foreach (var con in cons)
                    {
                        Console.WriteLine($"{con.Id} - Car: {con.CarId}, Customer: {con.CustomerId}, Tarih: {con.RentDate:d} - {con.ReturnDate:d}");
                    }
                }
                else
                {
                    Console.WriteLine(contracts.Message);
                }
                Console.ReadKey();
                break;
            case 4:
                var availableCars = await getAvailableCarsService.GetAvailableCarsAsync();
                ConsoleHelper.PrintList(availableCars.Data);
                break;
            case 5:
                Console.Write("Araba ID: ");
                string id = Console.ReadLine()!;
                var car = await getCarByIdService.GetCarByIdAsync(id);
                ConsoleHelper.PrintItem(car.Data);
                break;
            case 6:
                return;
        }

        ConsoleHelper.Pause();
    }

    static async Task CustomerMenu(User customer, RentCarService rentCarService, ReturnCarService returnCarService)
    {
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine($"Müşteri Girişi: {customer.Username}");
            Console.WriteLine("1) Araba Kirala");
            Console.WriteLine("2) Araba İade Et");
            Console.WriteLine("3) Çıkış");

            int choice = ConsoleHelper.GetChoice(1, 3);

            switch (choice)
            {
                case 1:
                    Console.Write("Sözleşme ID :(( : ");
                    string contractId = Console.ReadLine()!;
                    Console.Write("Kiralayacağınız Araba ID: ");
                    string carId = Console.ReadLine()!;
                    Console.Write("Şirket ID: ");
                    string companyId = Console.ReadLine()!;
                    Console.Write("Kiralama Tarihi (yyyy-MM-dd): ");
                    DateTime rentDate = DateTime.Parse(Console.ReadLine()!);
                    Console.Write("İade Tarihi (yyyy-MM-dd): ");
                    DateTime returnDate = DateTime.Parse(Console.ReadLine()!);

                    var rentRequest = new RentCarRequest
                    {
                        ContractId = contractId,
                        CarId = carId,
                        CompanyId = companyId,
                        CustomerId = customer.Id,
                        RentDate = rentDate,
                        ReturnDate = returnDate
                    };

                    var rentResult = await rentCarService.RentCarAsync(rentRequest);
                    Console.WriteLine(rentResult.Success ? "Kiralama başarılı." : $"Hata: {rentResult.Message}");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Write("İade edeceğiniz Araba ID: ");
                    string returnCarId = Console.ReadLine()!;
                    Console.Write("İade tarihi (yyyy-MM-dd): ");
                    string input = Console.ReadLine()!;

                    DateTime actualReturnDate;
                    while (!DateTime.TryParse(input, out actualReturnDate))
                    {
                        Console.Write("Geçerli bir tarih girin (yyyy-MM-dd): ");
                        input = Console.ReadLine()!;
                    }

                    var request = new ReturnCarRequest
                    {
                        CarId = returnCarId,
                        ActualReturnDate = actualReturnDate 
                    };

                    var returnResult = await returnCarService.ReturnCarAsync(request);
                    Console.WriteLine(returnResult.Success ? "Araç başarıyla iade edildi." : $"Hata: {returnResult.Message}");
                    Console.ReadKey();
                    break;
                case 3:
                    return;
            }
            ConsoleHelper.Pause();
        }
    }
}
