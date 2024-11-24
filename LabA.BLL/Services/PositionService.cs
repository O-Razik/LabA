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
}