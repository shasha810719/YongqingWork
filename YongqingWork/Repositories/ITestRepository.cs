
using YongqingWork.ViewModels;

namespace YongqingWork.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITestRepository
    {
        /// <summary>
        /// 取得客戶訂單列表
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns></returns>
        Task<IEnumerable<CustomerOrderViewModel>> GetCustomerOrderList(int orderId);

        /// <summary>
        /// 新增客戶訂單
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<bool> PostCustomerOrders(PostCustomerOrderViewModel data);
    }
}
