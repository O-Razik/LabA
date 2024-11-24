using LabA.Abstraction.IModel;
using LabA.Abstraction.IRepository;
using LabA.Abstraction.IServices;

namespace LabA.BLL.Services;

public class StatusService(IUnitOfWork unitOfWork) : IStatusService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<IEnumerable<IStatus>> GetAllStatusesAsync()
    {
        return await _unitOfWork.StatusRepository.GetAllStatusesAsync();
    }

    public async Task<IStatus?> GetStatusByIdAsync(int id)
    {
        return await _unitOfWork.StatusRepository.GetStatusByIdAsync(id);
    }

    public async Task<IStatus> AddStatusAsync(IStatus status)
    {
        return await _unitOfWork.StatusRepository.AddStatusAsync(status);
    }

    public async Task<IStatus?> UpdateStatusAsync(int id, IStatus status)
    {
        return await _unitOfWork.StatusRepository.UpdateStatusAsync(id, status);
    }

    public async Task<IStatus?> DeleteStatusAsync(int id)
    {
        return await _unitOfWork.StatusRepository.DeleteStatusAsync(id);
    }

    public void Validate(IStatus status)
    {
        if (status == null)
        {
            throw new ArgumentNullException(nameof(status));
        }

        if (status.StatusId < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(status.StatusId));
        }
    }
}