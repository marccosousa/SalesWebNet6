using Microsoft.AspNetCore.Mvc;

namespace SalesWebNet6.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
