using LabA.Abstraction.IModel;

namespace LabA.Abstraction.IRepository;

public interface IStatusRepository
{
    public Task<IEnumerable<IStatus>> GetAllStatusesAsync();
    public Task<IStatus?> GetStatusByIdAsync(int id);
    public Task<IStatus> AddStatusAsync(IStatus status);
    public Task<IStatus?> UpdateStatusAsync(int id, IStatus status);
    public Task<IStatus?> DeleteStatusAsync(int id);
}