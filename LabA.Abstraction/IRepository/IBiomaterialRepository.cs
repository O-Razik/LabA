using LabA.Abstraction.IModel;

namespace LabA.Abstraction.IRepository;

public interface IBiomaterialRepository
{
    public Task<IEnumerable<IBiomaterial>> GetAllBiomaterialsAsync();
    public Task<IBiomaterial?> GetBiomateralAsync(int id);
    public Task<IBiomaterial> AddBiomaterialAsync(IBiomaterial biomaterial);
    public Task<IBiomaterial?> UpdateBiomaterialAsync(int id, IBiomaterial biomaterial);
    public Task<IBiomaterial?> DeleteBiomaterialAsync(int id);
}