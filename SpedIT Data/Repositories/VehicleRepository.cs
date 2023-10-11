using Microsoft.EntityFrameworkCore;
using SpedIT_Domain;
using SpedIT_Domain.Models;
using SpedIT_Domain.Repositories;

namespace SpedIT_Data.Repositories
{
	public class VehicleRepository : IVehicleRepository
	{
		private readonly DataContext _context;

		public VehicleRepository(DataContext context)
		{
			_context = context;
		}

		public async Task<Vehicle> GetVehicleByIdAsync(int id)
		{
			return await _context.Vehicles.FindAsync(id);
		}

		public async Task<IEnumerable<Vehicle>> GetAllVehiclesAsync()
		{
			return await _context.Vehicles.ToListAsync();
		}

		public async Task<int> AddVehicleAsync(Vehicle vehicle)
		{
			_context.Vehicles.Add(vehicle);
			await _context.SaveChangesAsync();
			return vehicle.Id;
		}

		public async Task UpdateVehicleAsync(Vehicle vehicle)
		{
			_context.Entry(vehicle).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		public async Task DeleteVehicleAsync(int id)
		{
			var vehicle = await _context.Vehicles.FindAsync(id);
			if (vehicle != null)
			{
				_context.Vehicles.Remove(vehicle);
				await _context.SaveChangesAsync();
			}
		}
	}
}
