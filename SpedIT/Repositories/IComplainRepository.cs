using SpedIT_Domain.Models;

namespace SpedIT_Domain.Repositories
{
	public interface IComplainRepository
	{
		Task<IEnumerable<Complain>> GetAllComplainsAsync();

		Task<Complain> GetComplainByIdAsync(int id);

		Task AddComplainAsync(Complain complain);
        Task UpdateComplainAsync(Complain department);
        Task DeleteComplainAsync(int id);
    }
}
