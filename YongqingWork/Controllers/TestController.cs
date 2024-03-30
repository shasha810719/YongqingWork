using Microsoft.AspNetCore.Mvc;
using System.Net;
using YongqingWork.Services;

namespace YongqingWork.Controllers
{
    /// <summary>
    /// 測試專案
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : Controller
    {

        private ITestService _testService;

        /// <summary>
        /// 建構子
        /// </summary>
        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        /// <summary>
        /// 取得客戶列表
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns></returns>
        [HttpGet("GetCustomerList")]
        public async Task<IActionResult> GetCustomerList(string cityName)
        {
            try
            {
                var result = await _testService.GetCustomerList(cityName);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }

        }
    }
}
