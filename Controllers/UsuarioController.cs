using Microsoft.AspNetCore.Mvc;

namespace api_filmes_senai1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
