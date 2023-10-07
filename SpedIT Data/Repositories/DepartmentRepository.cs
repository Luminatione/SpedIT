using Microsoft.EntityFrameworkCore;
using SpedIT.Models;
using SpedIT_Domain.Repositories;

namespace SpedIT_Data.Repositories
{
	public class DepartmentRepository : IDepartmentRepository
	{
		private readonly SpedITContext _context;

		public DepartmentRepository(SpedITContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Department>> GetDepartments()
		{
			return await _context.Departments.ToListAsync();
		}

		public async Task<Department> GetDepartment(int id)
		{
			return await _context.Departments.FindAsync(id);
		}

		public async Task AddDepartment(Department department)
		{
			_context.Departments.Add(department);
			await _context.SaveChangesAsync();
		}
	}
}
