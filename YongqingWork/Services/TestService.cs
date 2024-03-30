
using Microsoft.AspNetCore.Mvc;
using YongqingWork.Repositories;

namespace YongqingWork.Services
{
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
        /// 取得客戶列表
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetCustomerList(string cityName)
        {
            if (string.IsNullOrEmpty(cityName))
            {
                return new BadRequestObjectResult("請輸入城市名稱");
            }

            var result = await _testRepository.GetCustomerList(cityName);

            return new OkObjectResult(result);

        }
    }
}
