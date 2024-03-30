using Microsoft.AspNetCore.Mvc;
using System.Net;
using YongqingWork.Services;
using YongqingWork.ViewModels;

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
        /// 取得客戶訂單列表
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns></returns>
        [HttpGet("GetCustomerOrderList")]
        public async Task<IActionResult> GetCustomerOrderList(int orderId)
        {
            try
            {
                var result = await _testService.GetCustomerOrderList(orderId);

                if (result == null)
                {
                    return StatusCode(HttpStatusCode.NotFound.GetHashCode(), $"此訂單{orderId}查無資料");
                }
                                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }
        }

        /// <summary>
        /// 新增客戶訂單
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns></returns>
        [HttpGet("PostCustomerOrders")]
        public async Task<IActionResult> PostCustomerOrders(PostCustomerOrderViewModel data)
        {
            try
            {
                var result = await _testService.PostCustomerOrders(data);                

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }
        }


    }
}
