using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using StateMvc.Models;
using StateMvc.Views;
using StateMvc.Views.User;
using Microsoft.AspNetCore.Http;

namespace StateMvc.Controllers
{
    public class UserController : Controller
    {
        private readonly DataService service;
        private readonly IMemoryCache cache;

        public UserController(DataService service, IMemoryCache cache)
        {
            this.service = service;
            this.cache = cache;
        }
        [HttpGet("")]
        [HttpGet("index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("")]
        [HttpPost("index")]
        public IActionResult Index(IndexVM indexVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            TempData["Message"] = "Your values have been saved";
            cache.Set("SupportEmail", indexVM.SupportEmail);
            HttpContext.Session.SetString("CompanyName", indexVM.CompanyName);
            service.AddUser(indexVM);

            return RedirectToAction(nameof(Display));
        }

        [HttpGet("settings/display")]
        public IActionResult Display()
        {
            DisplayVM model = new();
            model.SupportEmail = cache.Get<string>("SupportEmail");
            model.CompanyName =  HttpContext.Session.GetString("CompanyName");

            return View(model);
        }


    }
}
