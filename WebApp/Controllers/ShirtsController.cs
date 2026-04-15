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
            if (ModelState.IsValid)
            {
                var response = await _webApiExcuter.InvokePost("shirts", shirt);
                if(response != null)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            var shirts = await _webApiExcuter.InvokeGet<List<Shirt>>("shirts");
            return View(shirt);
        }

        public async Task<IActionResult> UpdateShirt(int id)
        {
            var shirt = await _webApiExcuter.InvokeGet<Shirt>($"shirts/{id}");
            if (shirt != null)
            {
                return View(shirt);
            }
            return NotFound();
        }
    }
}
