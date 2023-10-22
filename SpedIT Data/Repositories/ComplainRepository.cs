using Microsoft.EntityFrameworkCore;
using SpedIT.Models;
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

		public async Task<IEnumerable<Complain>> GetAllComplainsAsync()
		{
			return await _context.Complains.Include("Complainant").Include("Contested").ToListAsync();
		}

		public async Task<Complain> GetComplainByIdAsync(int id)
		{
			return await _context.Complains.FindAsync(id);
		}

		public async Task AddComplainAsync(Complain complain)
		{
			_context.Complains.Add(complain);
			await _context.SaveChangesAsync();
		}

        public async Task UpdateComplainAsync(Complain department)
        {
            _context.Complains.Update(department);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteComplainAsync(int id)
        {
            var complain = await _context.Complains.FindAsync(id);
            if (complain != null)
            {
                _context.Complains.Remove(complain);
                await _context.SaveChangesAsync();
            }
        }
    }
}
