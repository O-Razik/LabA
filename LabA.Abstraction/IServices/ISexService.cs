using LabA.Abstraction.IModel;

namespace LabA.Abstraction.IServices;

public interface ISexService
{
    public Task<IEnumerable<ISex>> GetAllSexesAsync();
    public Task<ISex?> GetSexByIdAsync(int id);
    public Task<ISex> AddSexAsync(ISex sex);
    public Task<ISex?> UpdateSexAsync(int id, ISex sex);
    public Task<ISex?> DeleteSexAsync(int id);

    public void Validate(ISex sex);
}