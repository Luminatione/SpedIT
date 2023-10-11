using Microsoft.EntityFrameworkCore;
using SpedIT.Models;
using SpedIT_Domain;
using SpedIT_Domain.Repositories;

namespace SpedIT_Data.Repositories
{
	public class PositionRepository : IPositionRepository
	{
		private readonly DataContext _context;

		public PositionRepository(DataContext context)
		{
			_context = context;
		}

		public async Task<Position> GetPositionByIdAsync(int id)
		{
			return await _context.Positions.FindAsync(id);
		}

		public async Task<IEnumerable<Position>> GetAllPositionsAsync()
		{
			return await _context.Positions.ToListAsync();
		}

		public async Task<int> AddPositionAsync(Position position)
		{
			_context.Positions.Add(position);
			await _context.SaveChangesAsync();
			return position.Id;
		}

		public async Task UpdatePositionAsync(Position position)
		{
			_context.Entry(position).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		public async Task DeletePositionAsync(int id)
		{
			var position = await _context.Positions.FindAsync(id);
			if (position != null)
			{
				_context.Positions.Remove(position);
				await _context.SaveChangesAsync();
			}
		}
	}
}
