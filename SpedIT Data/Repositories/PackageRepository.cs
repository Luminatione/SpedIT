using Microsoft.EntityFrameworkCore;
using SpedIT_Domain;
using SpedIT_Domain.Models;
using SpedIT_Domain.Repositories;

namespace SpedIT_Data.Repositories
{
	public class PackageRepository : IPackageRepository
	{
		private readonly DataContext _context;

		public PackageRepository(DataContext context)
		{
			_context = context;
		}

		public async Task<Package> GetPackageByIdAsync(int id)
		{
			return await _context.Packages.FindAsync(id);
		}

		public async Task<IEnumerable<Package>> GetAllPackagesAsync()
		{
			return await _context.Packages.ToListAsync();
		}

		public async Task<int> AddPackageAsync(Package package)
		{
			_context.Packages.Add(package);
			await _context.SaveChangesAsync();
			return package.Id;
		}

		public async Task UpdatePackageAsync(Package package)
		{
			_context.Entry(package).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		public async Task DeletePackageAsync(int id)
		{
			var package = await _context.Packages.FindAsync(id);
			if (package != null)
			{
				_context.Packages.Remove(package);
				await _context.SaveChangesAsync();
			}
		}
	}
}
