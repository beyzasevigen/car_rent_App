using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Shared
{
    public static class ConsoleHelper
{
    public static int GetChoice(int min, int max)
    {
        while (true)
        {
            Console.Write("Seçiminiz: ");
            var input = Console.ReadLine();
            if (int.TryParse(input, out int choice) && choice >= min && choice <= max)
                return choice;

            Console.WriteLine($"Lütfen {min}-{max} arasında bir sayı girin.");
        }
    }

    public static void Pause()
    {
        Console.WriteLine("Devam etmek için bir tuşa basın...");
        Console.ReadKey();
    }

        internal static void PrintItem(object? data)
        {
            if (data == null)
            {
                Console.WriteLine("Veri bulunamadı.");
                return;
            }

            Console.WriteLine("----- Detay -----");
            Console.WriteLine(data);
        }

        internal static void PrintList(object? data)
        {
            if (data == null)
            {
                Console.WriteLine("Liste boş veya null.");
                return;
            }

            if (data is System.Collections.IEnumerable list && !(data is string))
            {
                Console.WriteLine("----- Liste -----");

                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Bu bir liste değil.");
            }
        }

    }
}
