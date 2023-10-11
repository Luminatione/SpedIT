using Microsoft.EntityFrameworkCore;
using SpedIT_Domain;
using SpedIT_Domain.Models;
using SpedIT_Domain.Repositories;

namespace SpedIT_Data.Repositories
{
	public class InvoiceRepository : IInvoiceRepository
	{
		private readonly DataContext _context;

		public InvoiceRepository(DataContext context)
		{
			_context = context;
		}

		public async Task<Invoice> GetInvoiceByIdAsync(int id)
		{
			return await _context.Invoices.FindAsync(id);
		}

		public async Task<IEnumerable<Invoice>> GetAllInvoicesAsync()
		{
			return await _context.Invoices.ToListAsync();
		}

		public async Task<int> AddInvoiceAsync(Invoice invoice)
		{
			_context.Invoices.Add(invoice);
			await _context.SaveChangesAsync();
			return invoice.Id;
		}

		public async Task UpdateInvoiceAsync(Invoice invoice)
		{
			_context.Entry(invoice).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		public async Task DeleteInvoiceAsync(int id)
		{
			var invoice = await _context.Invoices.FindAsync(id);
			if (invoice != null)
			{
				_context.Invoices.Remove(invoice);
				await _context.SaveChangesAsync();
			}
		}
	}
}
