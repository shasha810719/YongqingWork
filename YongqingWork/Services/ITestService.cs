
using Microsoft.AspNetCore.Mvc;
using YongqingWork.ViewModels;

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

        /// <summary>
        /// 新增客戶訂單
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<IActionResult> PostCustomerOrders(PostCustomerOrderViewModel data);
    }
}
