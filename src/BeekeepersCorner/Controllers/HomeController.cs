using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BeekeepersCorner.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult One()
        {
            return View();
        }

        public IActionResult Two()
        {
            return View();
        }

        public IActionResult Three()
        {
            return View();
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Beekeepers Corner contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
