using LabA.Abstraction.IModel;
using LabA.Abstraction.IRepository;
using LabA.Abstraction.IServices;

namespace LabA.BLL.Services;

public class BiomaterailService(IUnitOfWork unitOfWork) : IBiomaterailService
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<IEnumerable<IBiomaterial>> GetAllBiomaterialsAsync()
    {
        return await unitOfWork.BiomaterailRepository.GetAllBiomaterialsAsync();
    }

    public async Task<IBiomaterial?> GetBiomateralAsync(int id)
    {
        return await unitOfWork.BiomaterailRepository.GetBiomateralAsync(id);
    }

    public async Task<IBiomaterial> AddBiomaterialAsync(IBiomaterial biomaterial)
    {
        return await unitOfWork.BiomaterailRepository.AddBiomaterialAsync(biomaterial);
    }

    public async Task<IBiomaterial?> UpdateBiomaterialAsync(int id, IBiomaterial biomaterial)
    {
        return await unitOfWork.BiomaterailRepository.UpdateBiomaterialAsync(id, biomaterial);
    }

    public async Task<IBiomaterial?> DeleteBiomaterialAsync(int id)
    {
        return await unitOfWork.BiomaterailRepository.DeleteBiomaterialAsync(id);
    }

    public void Validate(IBiomaterial biomaterial)
    {
        if (biomaterial == null)
        {
            throw new ArgumentNullException(nameof(biomaterial));
        }

        if (string.IsNullOrWhiteSpace(biomaterial.BiomaterialName))
        {
            throw new ArgumentException("Name is required", nameof(biomaterial.BiomaterialName));
        }

        if (biomaterial.BiomaterialId < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(biomaterial.BiomaterialId));
        }
    }
}