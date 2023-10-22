using Microsoft.EntityFrameworkCore;
using SpedIT.Models;
using SpedIT_Domain;
using SpedIT_Domain.Repositories;

namespace SpedIT_Data.Repositories
{
	public class EmployeeRepository : IEmployeeRepository
	{
		private readonly DataContext _context;

		public EmployeeRepository(DataContext context)
		{
			_context = context;
		}

		public async Task<Employee> GetEmployeeByIdAsync(int id)
		{
			return await _context.Employees.FindAsync(id);
		}

		public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
		{
			return await _context.Employees.Include("Position").Include("Department").ToListAsync();
		}

		public async Task<int> AddEmployeeAsync(Employee employee)
		{
			_context.Employees.Add(employee);
			await _context.SaveChangesAsync();
			return employee.Id;
		}

		public async Task UpdateEmployeeAsync(Employee employee)
		{
			_context.Entry(employee).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		public async Task DeleteEmployeeAsync(int id)
		{
			var employee = await _context.Employees.FindAsync(id);
			if (employee != null)
			{
				_context.Employees.Remove(employee);
				await _context.SaveChangesAsync();
			}
		}
	}
}
