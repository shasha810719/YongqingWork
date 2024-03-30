
using Microsoft.AspNetCore.Mvc;
using System.Net;
using YongqingWork.Repositories;
using YongqingWork.ViewModels;

namespace YongqingWork.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class TestService : ITestService
    {
        private ITestRepository _testRepository;

        /// <summary>
        /// 建構子
        /// </summary>
        public TestService(ITestRepository testRepository) 
        { 
            _testRepository = testRepository;
        }

        /// <summary>
        /// 取得客戶訂單列表
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetCustomerOrderList(int orderId)
        {

            var result = await _testRepository.GetCustomerOrderList(orderId);

            if (result == null || result.Count() == 0)
            {
                return null;
            }

            return new OkObjectResult(result);

        }

        /// <summary>
        /// 新增客戶訂單
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>        
        public async Task<IActionResult> PostCustomerOrders(PostCustomerOrderViewModel data)
        {

            //驗證資料正確性
            //Vaild()

            var result = await _testRepository.PostCustomerOrders(data);

            if (result == false)
            {
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
            
            return new OkResult();
            
        }
    }
}
