using LabA.Abstraction.IModel;
using LabA.Abstraction.IRepository;
using LabA.Abstraction.IServices;

namespace LabA.BLL.Services;

public class PositionService(IUnitOfWork unitOfWork) : IPositionService
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<IEnumerable<IPosition>> GetAllPositionsAsync()
    {
        return await unitOfWork.PositionRepository.GetAllPositionsAsync();
    }

    public async Task<IPosition?> GetPositionByIdAsync(int id)
    {
        return await unitOfWork.PositionRepository.GetPositionByIdAsync(id);
    }

    public async Task<IPosition> AddPositionAsync(IPosition position)
    {
        return await unitOfWork.PositionRepository.AddPositionAsync(position);
    }

    public async Task<IPosition?> UpdatePositionAsync(int id, IPosition position)
    {
        return await unitOfWork.PositionRepository.UpdatePositionAsync(id, position);
    }

    public async Task<IPosition?> DeletePositionAsync(int id)
    {
        return await unitOfWork.PositionRepository.DeletePositionAsync(id);
    }

    public void Validate(IPosition position)
    {
        if (position == null)
        {
            throw new ArgumentNullException("Position cannot be null");
        }
        if (position.PositionId < 0)
        {
            throw new ArgumentOutOfRangeException("Position id cannot be less than 0");
        }
        if (position.PositionName == null)
        {
            throw new ArgumentNullException("Position name cannot be null");
        }
        if (position.PositionName.Length < 3)
        {
            throw new ArgumentException("Position name must be at least 3 characters long");
        }
    }
}