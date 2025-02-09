using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
