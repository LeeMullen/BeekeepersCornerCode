using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BeekeepersCorner.Data;
using Microsoft.EntityFrameworkCore;
using BeekeepersCorner.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BeekeepersCorner.Controllers
{
    public class BeekeepersController : Controller
    {

        // Gets the Beekeepers data context from database
        private readonly BeekeepersDBContext _context;

        public BeekeepersController(BeekeepersDBContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Beekeepers()
        {
            return View(await _context.Beekeepers.ToListAsync());
        }

        // GET: /<controller>/
        public IActionResult Details(int id)
        {

            var beekeeper = _context.Beekeepers.FirstOrDefault(d => d.BeekeeperID == id);

            return View(beekeeper);
        }

        // GET: /<controller>/
        public IActionResult Create()
        {
            return View();
        }

        // POST: /<controller>/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FirstName,LastName,Address,City,State,Zipcode,Phone,Email")] Beekeeper beekeeper)
        {
            if (ModelState.IsValid)
            {

                _context.Beekeepers.Add(beekeeper);
                _context.SaveChanges();

                return RedirectToAction("Beekeepers");
            }
            return View(beekeeper);
        }

        // GET: /<controller>/
        public IActionResult Edit(int id)
        {
            
            var beekeeper = _context.Beekeepers.FirstOrDefault(d => d.BeekeeperID == id);
            
            return View(beekeeper);
        }

        // POST: /<controller>/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("BeekeeperID,FirstName,LastName,Address,City,State,Zipcode,Phone,Email")] Beekeeper beekeeper)
        {

            if (ModelState.IsValid)
            {
                _context.Entry(beekeeper).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Beekeepers");
            }
            return View(beekeeper);

        }

        // GET: /<controller>/
        public IActionResult Delete(int? id)
        {
            var beekeeperToDelete = new Beekeeper();

            if (id != null)
            {
                beekeeperToDelete = _context.Beekeepers.FirstOrDefault(d => d.BeekeeperID == id);

            }

            return View(beekeeperToDelete);

        }

        // POST: /<controller>/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([Bind("BeekeeperID")] Beekeeper beekeeper)
        {

            if (beekeeper != null)
            {
                var beekeeperToDelete = _context.Beekeepers.FirstOrDefault(d => d.BeekeeperID == beekeeper.BeekeeperID);

                _context.Entry(beekeeperToDelete).State = EntityState.Deleted;

                _context.SaveChanges();

                return RedirectToAction("Beekeepers");
            }

            return View(beekeeper);

        }

        //Angular JS controller methods

        // GET: /<controller>/
        public async Task<IActionResult> BeekeepersAJ()
        {
            return View("~/Views/BeekeepersAJ/BeekeepersAJ.cshtml", await _context.Beekeepers.ToListAsync());
        }

    }
}
