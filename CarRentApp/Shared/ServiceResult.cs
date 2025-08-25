using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Shared
{
    public class ServiceResult : IServiceResult
    {
        public bool HasError { get; private set; }
        public string? Message { get; private set; }
        public object? Data { get; private set; }
        public bool Success => !HasError;

        public static ServiceResult IsSuccess(object? data = null)
        {
            return new ServiceResult { HasError = false, Data = data };
        }

        public static ServiceResult Failure(string message)
        {
            return new ServiceResult { HasError = true, Message = message };
        }
    }
}

