using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BeekeepersCorner.Data;
using Microsoft.EntityFrameworkCore;
using BeekeepersCorner.Models;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BeekeepersCorner.Controllers
{
    public class BeehivesController : Controller
    {

        // Gets the Beekeepers data context from database
        private readonly BeekeepersDBContext _context;

        public BeehivesController(BeekeepersDBContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Beehives(int id)
        {
            var beekeeper = new Beekeeper();
            beekeeper = _context.Beekeepers.FirstOrDefault(d => d.BeekeeperID == id);
            
            ViewData["BeekeeperName"] = beekeeper.FirstName + " " + beekeeper.LastName;

            ViewData["BeekeeperID"] = id.ToString();

            HttpContext.Session.SetString("BeekeeperID", id.ToString());

            var Beehives = _context.Beehives.Where(b => b.BeekeeperIDFK == id);

            return View(Beehives);
        }

        // GET: /<controller>/
        public IActionResult Details(int id)
        {
            var beehive = _context.Beehives.FirstOrDefault(d => d.BeehiveID == id);
            var beekeeper = _context.Beekeepers.FirstOrDefault(d => d.BeekeeperID == beehive.BeekeeperIDFK);
            ViewData["BeekeeperName"] = beekeeper.FirstName + " " + beekeeper.LastName;

            return View(beehive);

        }

        // GET: /<controller>/
        public IActionResult Create(int id)
        {

            Beehive beehive = new Beehive();
            beehive.BeekeeperIDFK = id;

            return View(beehive);
        }

        // POST: /<controller>/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("HiveName,InstallDate,Notes,HoneyProduction")] Beehive beehive)
        {
            if (ModelState.IsValid)
            {
                beehive.BeekeeperIDFK = Convert.ToInt32(HttpContext.Session.GetString("BeekeeperID"));
                _context.Beehives.Add(beehive);
                _context.SaveChanges();

                return RedirectToAction("Beehives", routeValues: new
                    {
                        id = beehive.BeekeeperIDFK
                    });   
            }
            return View(beehive);
        }

        // GET: /<controller>/
        public IActionResult Edit(int id)
        {
            var beehive = _context.Beehives.FirstOrDefault(d => d.BeehiveID == id);
            var beekeeper = _context.Beekeepers.FirstOrDefault(d => d.BeekeeperID == beehive.BeekeeperIDFK);
            ViewData["BeekeeperName"] = beekeeper.FirstName + " " + beekeeper.LastName;
            
            return View(beehive);

        }

        // POST: /<controller>/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("BeekeeperIDFK,HiveName,InstallDate,Notes,HoneyProduction")] Beehive beehive)
        {

            if (ModelState.IsValid)
            {
                _context.Entry(beehive).State = EntityState.Modified;
                _context.SaveChanges();

                try
                {
                    // Attempt to save changes to the database
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    foreach (var entry in ex.Entries)
                    {
                        if (entry.Entity is Beehive)
                        {
                            // Using a NoTracking query means we get the entity but it is not tracked by the context
                            // and will not be merged with existing entities in the context.
                            var databaseEntity = _context.Beehives.AsNoTracking().Single(p => p.BeehiveID == ((Beehive)entry.Entity).BeehiveID);
                            var databaseEntry = _context.Entry(databaseEntity);

                            foreach (var property in entry.Metadata.GetProperties())
                            {
                                var proposedValue = entry.Property(property.Name).CurrentValue;
                                var originalValue = entry.Property(property.Name).OriginalValue;
                                var databaseValue = databaseEntry.Property(property.Name).CurrentValue;

                                // TODO: Logic to decide which value should be written to database
                                // entry.Property(property.Name).CurrentValue = <value to be saved>;

                                // Update original values to
                                entry.Property(property.Name).OriginalValue = databaseEntry.Property(property.Name).CurrentValue;
                            }
                        }
                        else
                        {
                            throw new NotSupportedException("Don't know how to handle concurrency conflicts for " + entry.Metadata.Name);
                        }
                    }

                    // Retry the save operation
                    _context.SaveChanges();
                }

                return RedirectToAction("Beehives", routeValues: new
                {
                    id = beehive.BeekeeperIDFK
                });
            }
            return View(beehive);

        }

        // GET: /<controller>/
        public IActionResult Delete(int? id)
        {
            var beehiveToDelete = new Beehive();

            if (id != null)
            {
                beehiveToDelete = _context.Beehives.FirstOrDefault(d => d.BeehiveID == id);

            }

            return View(beehiveToDelete);

        }

        // POST: /<controller>/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([Bind("BeehiveID")] Beehive beehive)
        {

            if (beehive != null)
            {
                
                var beehiveToDelete = _context.Beehives.FirstOrDefault(d => d.BeehiveID == beehive.BeehiveID);

                _context.Entry(beehiveToDelete).State = EntityState.Deleted;

                _context.SaveChanges();

                return RedirectToAction("Beehives", routeValues: new
                {
                    id = Convert.ToInt32(HttpContext.Session.GetString("BeekeeperID"))
                });
            }

            return View(beehive);

        }
    }
}
