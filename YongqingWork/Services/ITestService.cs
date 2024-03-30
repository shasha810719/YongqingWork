
using Microsoft.AspNetCore.Mvc;

namespace YongqingWork.Services
{
    public interface ITestService
    {
        Task<IActionResult> GetCustomerList(string cityName);
    }
}
