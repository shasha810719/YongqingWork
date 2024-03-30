
using Microsoft.AspNetCore.Mvc;

namespace YongqingWork.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITestService
    {

        /// <summary>
        /// 取得客戶訂單列表
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<IActionResult> GetCustomerOrderList(int orderId);
    }
}
