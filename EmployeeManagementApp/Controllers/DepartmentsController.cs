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
    public class DepartmentsController : Controller
    {
        private readonly AppDbContext _context;

        public DepartmentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Departments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Departments.ToListAsync());
        }


        // GET: Departments/Create
        [HttpGet]
        public IActionResult Create()
        {
            var department = new Department
            {
                Id = Guid.NewGuid().ToString() // Generate a unique ID here
            };
            return View(department);
        }


        // POST: Departments/Create
        [HttpPost]
        public IActionResult Create(Department department)
        {
            //department.Id = Guid.NewGuid().ToString();

            if (ModelState.IsValid)
            {
                

                // Add the department to the database
                _context.Departments.Add(department);
                _context.SaveChanges();

                // Set success message in TempData
                TempData["insert_success"] = "Department created successfully!";

                // Redirect to the index action
                return RedirectToAction("Index");
            }

            // If ModelState is invalid, return to the Create view
            return View(department);
        }


        // GET: Departments/Edit/5

        public IActionResult Update(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = _context.Departments.FirstOrDefault(d => d.Id == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Departments/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(string id, Department department)
        {
            if (id != department.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Departments.Update(department);
                    _context.SaveChanges();

                    TempData["update_success"] = "Department updated successfully!";
                }
                catch (Exception)
                {
                    if (!_context.Departments.Any(d => d.Id == id))
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

            return View(department);
        }

        // GET: Departments/Delete/5
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = _context.Departments.FirstOrDefault(d => d.Id == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Departments/Delete/5
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var department = _context.Departments.FirstOrDefault(d => d.Id == id);
            if (department == null)
            {
                return NotFound();
            }

            _context.Departments.Remove(department);
            _context.SaveChanges();

            TempData["delete_success"] = "Department deleted successfully!";

            return RedirectToAction("Index");
        }
    }
}

