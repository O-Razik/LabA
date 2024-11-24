using LabA.Abstraction.IModel;

namespace LabA.Abstraction.IServices;

public interface IPositionService
{
    public Task<IEnumerable<IPosition>> GetAllPositionsAsync();
    public Task<IPosition?> GetPositionByIdAsync(int id);
    public Task<IPosition> AddPositionAsync(IPosition position);
    public Task<IPosition?> UpdatePositionAsync(int id, IPosition position);
    public Task<IPosition?> DeletePositionAsync(int id);

    public void Validate(IPosition position);
}