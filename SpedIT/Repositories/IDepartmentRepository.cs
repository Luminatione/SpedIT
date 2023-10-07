using SpedIT.Models;

namespace SpedIT_Domain.Repositories
{
	public interface IDepartmentRepository
	{
		Task<IEnumerable<Department>> GetDepartments();

		Task<Department> GetDepartment(int id);

		Task AddDepartment(Department department);
	}
}
