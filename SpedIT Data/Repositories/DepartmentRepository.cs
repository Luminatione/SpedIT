using Microsoft.EntityFrameworkCore;
using SpedIT.Models;
using SpedIT_Domain;
using SpedIT_Domain.Repositories;

namespace SpedIT_Data.Repositories
{
	public class DepartmentRepository : IDepartmentRepository
	{
		private readonly DataContext _context;

		public DepartmentRepository(DataContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
		{
			return await _context.Departments.ToListAsync();
		}

		public async Task<Department> GetDepartmentByIdAsync(int id)
		{
			return await _context.Departments.FindAsync(id);
		}

		public async Task<int> AddDepartmentAsync(Department department)
		{
			_context.Departments.Add(department);
			await _context.SaveChangesAsync();
			return department.Id;
		}

		public async Task UpdateDepartmentAsync(Department department)
		{
			_context.Departments.Update(department);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department != null)
            {
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
            }
        }
    }
}
