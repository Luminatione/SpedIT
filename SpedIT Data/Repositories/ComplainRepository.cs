using Microsoft.EntityFrameworkCore;
using SpedIT_Domain;
using SpedIT_Domain.Models;
using SpedIT_Domain.Repositories;

namespace SpedIT_Data.Repositories
{
	public class ComplainRepository : IComplainRepository
	{
		private readonly DataContext _context;

		public ComplainRepository(DataContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Complain>> GetComplains()
		{
			return await _context.Complains.ToListAsync();
		}

		public async Task<Complain> GetComplain(int id)
		{
			return await _context.Complains.FindAsync(id);
		}

		public async Task AddComplain(Complain complain)
		{
			_context.Complains.Add(complain);
			await _context.SaveChangesAsync();
		}
	}
}
