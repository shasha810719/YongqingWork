
using YongqingWork.ViewModels;

namespace YongqingWork.Repositories
{
    public interface ITestRepository
    {
        /// <summary>
        /// 取得客戶列表
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns></returns>
        Task<IEnumerable<CustomerViewModel>> GetCustomerList(string cityName);
    }
}
