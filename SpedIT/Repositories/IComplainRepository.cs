using SpedIT_Domain.Models;

namespace SpedIT_Domain.Repositories
{
	public interface IComplainRepository
	{
		Task<IEnumerable<Complain>> GetComplains();

		Task<Complain> GetComplain(int id);

		Task AddComplain(Complain complain);
	}
}
