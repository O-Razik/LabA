using LabA.Abstraction.IModel;

namespace LabA.Abstraction.IRepository;

public interface ISexRepository
{
    public Task<IEnumerable<ISex>> GetAllSexesAsync();
    public Task<ISex?> GetSexByIdAsync(int id);
}