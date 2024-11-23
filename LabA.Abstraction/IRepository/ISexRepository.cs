using LabA.Abstraction.IModel;

namespace LabA.Abstraction.IRepository;

public interface ISexRepository
{
    public Task<IEnumerable<ISex>> GetAllSexesAsync();
    public Task<ISex?> GetSexById(int id);
    public Task<ISex> AddSexAsync(ISex sex);
    public Task<ISex?> UpdateSexAsync(int id, ISex sex);
    public Task<ISex?> DeleteSexAsync(int id);
}