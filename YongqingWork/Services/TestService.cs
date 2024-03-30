
using Microsoft.AspNetCore.Mvc;
using System.Net;
using YongqingWork.Repositories;

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
    }
}
