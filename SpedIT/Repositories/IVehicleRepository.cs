using SpedIT_Domain.Models;

namespace SpedIT_Domain.Repositories
{
	public interface IVehicleRepository
	{
		Task<Vehicle> GetVehicleByIdAsync(int id);

		Task<IEnumerable<Vehicle>> GetAllVehiclesAsync();

		Task<int> AddVehicleAsync(Vehicle vehicle);

		Task UpdateVehicleAsync(Vehicle vehicle);

		Task DeleteVehicleAsync(int id);
	}
}
