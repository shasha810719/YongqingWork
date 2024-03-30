
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
    }
}
