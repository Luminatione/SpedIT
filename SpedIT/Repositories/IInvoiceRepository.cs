using SpedIT_Domain.Models;

namespace SpedIT_Domain.Repositories
{
	public interface IInvoiceRepository
	{
		Task<Invoice> GetInvoiceByIdAsync(int id);

		Task<IEnumerable<Invoice>> GetAllInvoicesAsync();

		Task<int> AddInvoiceAsync(Invoice invoice);

		Task UpdateInvoiceAsync(Invoice invoice);

		Task DeleteInvoiceAsync(int id);
	}
}
