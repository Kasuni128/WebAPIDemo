using Microsoft.AspNetCore.Mvc;
using WebApp.Data;
using WebAPP.Model;
using WebAPP.Model.Repositories;

namespace WebApp.Controllers
{
    public class ShirtsController : Controller
    {
        private readonly IWebApiExcuter _webApiExcuter;

        public ShirtsController(IWebApiExcuter webApiExcuter)
        {
            _webApiExcuter = webApiExcuter;
        }

        public async Task<IActionResult> Index()
        {
            var shirts = await _webApiExcuter.InvokeGet<List<Shirt>>("shirts");
            return View(shirts);
        }

        public IActionResult CreateShirt()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateShirt(Shirt shirt)
        {
            var shirts = await _webApiExcuter.InvokeGet<List<Shirt>>("shirts");
            return View(shirt);
        }
    }
}
