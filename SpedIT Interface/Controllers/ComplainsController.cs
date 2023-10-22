using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpedIT_Domain;
using SpedIT_Domain.Models;
using SpedIT_Domain.Repositories;

namespace SpedIT_Interface.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComplainsController : Controller
    {
        private readonly IComplainRepository complainRepository;
        private readonly IEmployeeRepository employeeRepository;

        public ComplainsController(IEmployeeRepository employeeRepository, IComplainRepository complainRepository)
        {
            this.employeeRepository = employeeRepository;
            this.complainRepository = complainRepository;
        }

        // GET: Complains
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await complainRepository.GetAllComplainsAsync());
        }

        // GET: Complains/Details/5
        [HttpGet("{id}/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || complainRepository.GetAllComplainsAsync() == null)
            {
                return NotFound();
            }

            var complain = await complainRepository.GetComplainByIdAsync(id.Value);
            if (complain == null)
            {
                return NotFound();
            }

            return View(complain);
        }

        // GET: Complains/Create
        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            await AddEmplyeesDispalyNamesToViewData();
            return View();
        }

        // POST: Complains/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Complain complain)
        {
            if (ModelState.IsValid)
            {
                await complainRepository.AddComplainAsync(complain);
                return RedirectToAction(nameof(Index));
            }
            await AddEmplyeesDispalyNamesToViewData();
            return View(complain);
        }

        // GET: Complains/Edit/5
        [HttpGet("{id}/Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || complainRepository.GetAllComplainsAsync() == null)
            {
                return NotFound();
            }

            var complain = await complainRepository.GetComplainByIdAsync(id.Value);
            if (complain == null)
            {
                return NotFound();
            }
            await AddEmplyeesDispalyNamesToViewData();
            return View(complain);
        }

        // POST: Complains/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("{id}/Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromForm] Complain complain)
        {
            if (id != complain.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await complainRepository.UpdateComplainAsync(complain);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (complainRepository.GetComplainByIdAsync(id) == null)
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
            await AddEmplyeesDispalyNamesToViewData();
            return View(complain);
        }

        // GET: Complains/Delete/5
        [HttpGet("{id}/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || complainRepository.GetAllComplainsAsync() == null)
            {
                return NotFound();
            }

            var complain = await complainRepository.GetComplainByIdAsync(id.Value);
            if (complain == null)
            {
                return NotFound();
            }

            return View(complain);
        }

        // POST: Complains/Delete/5
        [HttpPost("{id}/Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await complainRepository.GetAllComplainsAsync() == null)
            {
                return Problem("Entity set 'DataContext.Complains'  is null.");
            }
            await complainRepository.DeleteComplainAsync(id);
            
            return RedirectToAction(nameof(Index));
        }

        private async Task AddEmplyeesDispalyNamesToViewData()
        {
            var emplyeesDisplayNames = (await employeeRepository.GetAllEmployeesAsync()).ToList().Select(e => new { e.Id, DisplayName = e.FirstName + " " + e.LastName });
            ViewData["ComplainantId"] = new SelectList(emplyeesDisplayNames, "Id", "DisplayName");
            ViewData["ContestedId"] = new SelectList(emplyeesDisplayNames, "Id", "DisplayName");
        }
    }
}
