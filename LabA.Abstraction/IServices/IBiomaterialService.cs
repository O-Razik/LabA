using LabA.Abstraction.IModel;

namespace LabA.Abstraction.IServices;

public interface IBiomaterialService
{
    public Task<IEnumerable<IBiomaterial>> GetAllBiomaterialsAsync();
    public Task<IBiomaterial?> GetBiomaterialByIdAsync(int id);
    public Task<IBiomaterial> AddBiomaterialAsync(IBiomaterial biomaterial);
    public Task<IBiomaterial?> UpdateBiomaterialAsync(int id, IBiomaterial biomaterial);
    public Task<IBiomaterial?> DeleteBiomaterialAsync(int id);

    public void Validate(IBiomaterial biomaterial);
}