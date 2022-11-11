using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
