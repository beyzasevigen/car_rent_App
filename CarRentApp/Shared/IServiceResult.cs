using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Shared
{
    public interface IServiceResult
    {
        bool HasError { get; }
        string? Message { get; }
        object? Data { get; }
        bool Success { get; }
    }
}

