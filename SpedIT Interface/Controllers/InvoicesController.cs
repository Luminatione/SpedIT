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
    public class InvoicesController : Controller
    {
        private readonly IInvoiceRepository invoiceRepository;

        public InvoicesController(IInvoiceRepository invoiceRepository)
        {
            this.invoiceRepository = invoiceRepository;
        }

        // GET: Invoices
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await invoiceRepository.GetAllInvoicesAsync());
        }

        // GET: Invoices/Details/5
        [HttpGet("{id}/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || invoiceRepository.GetAllInvoicesAsync() == null)
            {
                return NotFound();
            }

            var invoice = await invoiceRepository.GetInvoiceByIdAsync(id.Value);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // GET: Invoices/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                await invoiceRepository.AddInvoiceAsync(invoice);
                return RedirectToAction(nameof(Index));
            }
            return View(invoice);
        }

        // GET: Invoices/Edit/5
        [HttpGet("{id}/Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || invoiceRepository.GetAllInvoicesAsync() == null)
            {
                return NotFound();
            }

            var invoice = await invoiceRepository.GetInvoiceByIdAsync(id.Value);
            if (invoice == null)
            {
                return NotFound();
            }
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("{id}/Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromForm] Invoice invoice)
        {
            if (id != invoice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await invoiceRepository.UpdateInvoiceAsync(invoice);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (invoiceRepository.GetInvoiceByIdAsync(id) == null)
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
            return View(invoice);
        }

        // GET: Invoices/Delete/5
        [HttpGet("{id}/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || invoiceRepository.GetAllInvoicesAsync() == null)
            {
                return NotFound();
            }

            var invoice = await invoiceRepository.GetInvoiceByIdAsync(id.Value);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost("{id}/Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (invoiceRepository.GetAllInvoicesAsync() == null)
            {
                return Problem("Entity set 'DataContext.Invoices'  is null.");
            }
            await invoiceRepository.DeleteInvoiceAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
