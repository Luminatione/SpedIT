using SpedIT.Models;

namespace SpedIT_Domain.Repositories
{
	public interface IDepartmentRepository
	{
		Task<IEnumerable<Department>> GetAllDepartmentsAsync();

		Task<Department> GetDepartmentByIdAsync(int id);

		Task<int> AddDepartmentAsync(Department department);
        Task UpdateDepartmentAsync(Department department);
        Task DeleteDepartmentAsync(int id);
    }
}
