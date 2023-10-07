using SpedIT.Models;

namespace SpedIT_Domain.Repositories
{
	public interface IEmployeeRepository
	{
		Task<Employee> GetEmployeeByIdAsync(int id);

		Task<IEnumerable<Employee>> GetAllEmployeesAsync();

		Task<int> AddEmployeeAsync(Employee employee);

		Task UpdateEmployeeAsync(Employee employee);

		Task DeleteEmployeeAsync(int id);
	}
}
