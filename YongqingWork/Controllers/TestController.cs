using Microsoft.AspNetCore.Mvc;

namespace YongqingWork.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
