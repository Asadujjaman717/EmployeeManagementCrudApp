using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementApp.Data;
using EmployeeManagementApp.Models;

namespace EmployeeManagementApp.Controllers
{
    public class DesignationsController : Controller
    {
        private readonly AppDbContext _context;

        public DesignationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Designations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Designations.ToListAsync());
        }



        // GET: Designations/Create

        [HttpGet]
        public IActionResult Create()
        {
            var designation = new Designation
            {
                Id = Guid.NewGuid().ToString() // Generate a unique ID here
            };
            return View(designation);
        }


        // POST: Designations/Create   

        [HttpPost]
        public IActionResult Create(Designation designation)
        {
            //department.Id = Guid.NewGuid().ToString();

            if (ModelState.IsValid)
            {
                // Generate a unique ID for the department


                // Add the department to the database
                _context.Designations.Add(designation);
                _context.SaveChanges();

                // Set success message in TempData
                TempData["insert_success"] = "Designation created successfully!";

                // Redirect to the index action
                return RedirectToAction("Index");
            }

            // If ModelState is invalid, return to the Create view
            return View(designation);
        }




        // GET: Designations/Edit/5
        public IActionResult Update(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var designation = _context.Designations.FirstOrDefault(d => d.Id == id);
            if (designation == null)
            {
                return NotFound();
            }

            return View(designation);
        }

       

        // POST: Designations/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(string id, Designation designation)
        {
            if (id != designation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Designations.Update(designation);
                    _context.SaveChanges();

                    TempData["update_success"] = "Designation updated successfully!";
                }
                catch (Exception)
                {
                    if (!_context.Designations.Any(d => d.Id == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction("Index");
            }

            return View(designation);
        }

        // GET: Designations/Delete/5

        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var designation = _context.Designations.FirstOrDefault(d => d.Id == id);
            if (designation == null)
            {
                return NotFound();
            }

            return View(designation);
        }

        // POST: Designations/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var designation= _context.Designations.FirstOrDefault(d => d.Id == id);
            if (designation == null)
            {
                return NotFound();
            }

            _context.Designations.Remove(designation);
            _context.SaveChanges();

            TempData["delete_success"] = "Designation deleted successfully!";

            return RedirectToAction("Index");
        }

    }
}
