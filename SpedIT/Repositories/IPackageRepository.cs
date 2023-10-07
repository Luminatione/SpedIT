using SpedIT_Domain.Models;

namespace SpedIT_Domain.Repositories
{
	public interface IPackageRepository
	{
		Task<Package> GetPackageByIdAsync(int id);

		Task<IEnumerable<Package>> GetAllPackagesAsync();

		Task<int> AddPackageAsync(Package package);

		Task UpdatePackageAsync(Package package);

		Task DeletePackageAsync(int id);
	}
}
