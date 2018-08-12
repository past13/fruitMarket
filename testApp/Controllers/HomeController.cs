using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using testApp.Models;
using testApp.Service.Interface;

namespace testApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFruitService _service;

        public HomeController(IFruitService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            IList<FruitDTO> model = _service.GetFruitList();
            return View(model);
        }

        public IActionResult Delete(int Id)
        {
            var result = _service.Delete(Id);
            return View("Index", result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Fruit fruit)
        {
            var result = _service.Add(fruit);
            return View("Index", result);
        }

        [HttpGet]
        public IActionResult ShowExpired()
        {
            var dateNow = DateTime.Now.Date;
            var result = _service.GetExpiredFruits(dateNow);
            return View("Index", result);
        }

        [HttpGet]
        public IActionResult GetReversedList()
        {
            var dateNow = DateTime.Now.Date;
            var result = _service.GetReversedList();
            return View("Index", result);
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
