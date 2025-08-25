using CarRentApp.Commands.Notifications.CreateCompany;
using CarRentApp.Commands.Requests.CreateCar;
using CarRentApp.Commands.Requests.CreateCompanyErroLog;
using CarRentApp.Models.CarRentApp.Models;
using CarRentApp.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Services
{
    public class UserService
    {
        private readonly List<User> _users = new List<User>();

        public UserService()
        {
            // Varsayılan admin kullanıcı
            _users.Add(new User
            {
                Username = "admin",
                Password = "admin123",
                Role = UserRole.Admin
            });
        }

        public bool Register(string username, string password, UserRole role = UserRole.Customer)
        {
            if (_users.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
                return false;

            _users.Add(new User
            {
                Username = username,
                Password = password,
                Role = role
            });

            return true;
        }

        public User? Login(string username, string password)
        {
            return _users.FirstOrDefault(u =>
                u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) &&
                u.Password == password);
        }

        public List<User> GetAllUsers() => _users;
    
    }
}