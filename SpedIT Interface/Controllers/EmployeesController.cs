using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpedIT.Models;
using SpedIT_Domain;
using SpedIT_Domain.Repositories;

namespace SpedIT_Interface.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : Controller
    {
        private readonly IPositionRepository positionRepository;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IDepartmentRepository departmentRepository;

        public EmployeesController(IPositionRepository positionRepository, IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository)
        {
            this.positionRepository = positionRepository;
            this.employeeRepository = employeeRepository;
            this.departmentRepository = departmentRepository;
        }

        // GET: Employees
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await employeeRepository.GetAllEmployeesAsync());
        }

        // GET: Employees/Details/5
        [HttpGet("{id}/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || employeeRepository.GetAllEmployeesAsync() == null)
            {
                return NotFound();
            }

            var employee = await employeeRepository.GetEmployeeByIdAsync(id.Value);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            await AddViewData();
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Employee employee)
        {
            if (ModelState.IsValid)
            {
                await employeeRepository.AddEmployeeAsync(employee);
                return RedirectToAction(nameof(Index));
            }
            await AddViewData();
            return View(employee);
        }

        // GET: Employees/Edit/5
        [HttpGet("{id}/Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || await employeeRepository.GetAllEmployeesAsync() == null)
            {
                return NotFound();
            }

            var employee = await employeeRepository.GetEmployeeByIdAsync(id.Value);
            if (employee == null)
            {
                return NotFound();
            }
            await AddViewData();
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("{id}/Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromForm] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await employeeRepository.UpdateEmployeeAsync(employee);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (employeeRepository.GetEmployeeByIdAsync(id) == null)
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
            await AddViewData();
            return View(employee);
        }

        // GET: Employees/Delete/5
        [HttpGet("{id}/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || await employeeRepository.GetAllEmployeesAsync() == null)
            {
                return NotFound();
            }

            var employee = await employeeRepository.GetEmployeeByIdAsync(id.Value);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost("{id}/Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (employeeRepository.GetAllEmployeesAsync() == null)
            {
                return Problem("Entity set 'DataContext.Employees'  is null.");
            }
            await employeeRepository.DeleteEmployeeAsync(id);
            return RedirectToAction(nameof(Index));
        }
        
        private async Task AddViewData()
        {
            ViewData["DepartmentId"] = new SelectList(await departmentRepository.GetAllDepartmentsAsync(), "Id", "Name");
            ViewData["PositionId"] = new SelectList(await positionRepository.GetAllPositionsAsync(), "Id", "Name");
        }
    }
}
