using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpedIT.Models;
using SpedIT_Data.Repositories;
using SpedIT_Domain;
using SpedIT_Domain.Repositories;

namespace SpedIT_Interface.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class DepartmentsController : Controller
    {
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentsController(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

		// GET: Departments
		[HttpGet]
		public async Task<IActionResult> Index()
        {
            var departments = await departmentRepository.GetAllDepartmentsAsync();
            return departments != null ? View(departments) : Problem("Entity set 'DataContext.Departments' is null.");
        }

		// GET: Departments/Details/5
		[HttpGet("{id}/Details")]
		public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await departmentRepository.GetDepartmentByIdAsync(id.Value);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

		// GET: Departments/Create
		[HttpGet("Create")]
		public IActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Department department)
        {
            if (ModelState.IsValid)
            {
                await departmentRepository.AddDepartmentAsync(department);
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

		// GET: Departments/Edit/5
		[HttpGet("{id}/Edit")]
		public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await departmentRepository.GetDepartmentByIdAsync(id.Value);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("{id}/Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromForm] Department department)
        {
            if (id != department.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await departmentRepository.UpdateDepartmentAsync(department);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (departmentRepository.GetDepartmentByIdAsync(department.Id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

		// GET: Departments/Delete/5
		[HttpGet("{id}/Delete")]
		public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await departmentRepository.GetDepartmentByIdAsync(id.Value);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost("{id}/Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {         
            await departmentRepository.DeleteDepartmentAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
