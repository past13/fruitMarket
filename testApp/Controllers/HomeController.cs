using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using testApp.Models;
using testApp.Service.Interface;

namespace testApp.Controllers
{
    public class HomeController : Controller
    {
        readonly IFruitService _service;

        public HomeController(IFruitService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View(_service.GetFruitList());
        }

        public IActionResult GetFruit(int Id)
        {
            return View(_service.GetFruit(Id));
        }

        public IActionResult DeleteFruit(int Id)
        {
            return View("Index", _service.Delete(Id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Fruit fruit)
        {
            return View("Index", _service.Add(fruit));
        }

        [HttpGet]
        public IActionResult ShowExpired()
        {
            return View("Index", _service.GetExpiredFruits(DateTime.Now.Date));
        }

        [HttpGet]
        public IActionResult GetReversedList()
        {
            return View("Index", _service.GetReversedList());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
