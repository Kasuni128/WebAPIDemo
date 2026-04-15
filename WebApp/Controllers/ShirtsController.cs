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
                try
                {
                    var response = await _webApiExcuter.InvokePost("shirts", shirt);
                    if (response != null)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (WebApiException ex)
                {
                    if (ex.ErrorResponse != null &&
                        ex.ErrorResponse.Errors != null &&
                        ex.ErrorResponse.Errors.Count > 0)
                    {
                        foreach (var error in ex.ErrorResponse.Errors)
                        {
                            ModelState.AddModelError(error.Key, string.Join("; ", error.Value));
                        }
                    }
                }
            }
                
                
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

        [HttpPost]
        public async Task<IActionResult> UpdateShirt(Shirt shirt)
        {
            if (ModelState.IsValid)
            {
                await _webApiExcuter.InvokePut($"shirts/{shirt.ShirtId}", shirt);
                return RedirectToAction(nameof(Index));
             
            }

            return View(shirt);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteShirt([FromForm] int id)
        {
            await _webApiExcuter.InvokeDelete($"shirts/{id}");
            return RedirectToAction(nameof(Index));

        }
      
    }
}
