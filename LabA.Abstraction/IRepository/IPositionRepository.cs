using LabA.Abstraction.IModel;

namespace LabA.Abstraction.IRepository;

public interface IPositionRepository
{
    public Task<IEnumerable<IPosition>> GetAllPositionsAsync();
    public Task<IPosition?> GetPositionByIdAsync(int id);
    public Task<IPosition> AddPositionAsync(IPosition position);
    public Task<IPosition?> UpdatePositionAsync(int id, IPosition position);
    public Task<IPosition?> DeletePositionAsync(int id);
}