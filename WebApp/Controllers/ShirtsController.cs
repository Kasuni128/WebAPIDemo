using Microsoft.AspNetCore.Mvc;
using WebAPP.Model.Repositories;

namespace WebApp.Controllers
{
    public class ShirtsController : Controller
    {
        public IActionResult Index()
        {
            return View(ShirtRepository.GetAllShirts());
        }
    }
}
