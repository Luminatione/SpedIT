using SpedIT.Models;

namespace SpedIT_Domain.Repositories
{
	public interface IPositionRepository
	{
		Task<Position> GetPositionByIdAsync(int id);

		Task<IEnumerable<Position>> GetAllPositionsAsync();

		Task<int> AddPositionAsync(Position position);

		Task UpdatePositionAsync(Position position);

		Task DeletePositionAsync(int id);
	}
}
