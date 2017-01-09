using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BeekeepersCorner.Models;
using BeekeepersCorner.Data;
using Microsoft.EntityFrameworkCore;

namespace BeekeepersCorner.Controllers
{
    public class BeekeepersAJController : Controller
    {

        // Gets the Beekeepers data context from database
        private readonly BeekeepersDBContext _context;

        public BeekeepersAJController(BeekeepersDBContext context)
        {
            _context = context;
        }

        public IActionResult BeekeepersAJ()
        {
            return View();
        }

        [Route("/BeekeepersAJ/GetBeekeepers")]
        public JsonResult GetBeekeepers()
        {
            var beekeepers = new List<Beekeeper>(_context.Beekeepers.ToList());
            /*
            var beekeepers = new List<Beekeeper>()
            {
                new Beekeeper { BeekeeperID = 1, FirstName = "John", LastName = "Doe" },
                new Beekeeper { BeekeeperID = 2, FirstName = "Mary", LastName = "Jane" },
                new Beekeeper { BeekeeperID = 3, FirstName = "Bob", LastName = "Parker" }
            };
            */
            

            return Json(beekeepers);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

    }
}
