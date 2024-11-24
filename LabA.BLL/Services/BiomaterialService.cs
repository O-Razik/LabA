using LabA.Abstraction.IModel;
using LabA.Abstraction.IRepository;
using LabA.Abstraction.IServices;

namespace LabA.BLL.Services;

public class BiomaterialService(IUnitOfWork unitOfWork) : IBiomaterialService
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<IEnumerable<IBiomaterial>> GetAllBiomaterialsAsync()
    {
        return await unitOfWork.BiomaterialRepository.GetAllBiomaterialsAsync();
    }

    public async Task<IBiomaterial?> GetBiomaterialByIdAsync(int id)
    {
        return await unitOfWork.BiomaterialRepository.GetBiomateralAsync(id);
    }

    public async Task<IBiomaterial> AddBiomaterialAsync(IBiomaterial biomaterial)
    {
        return await unitOfWork.BiomaterialRepository.AddBiomaterialAsync(biomaterial);
    }

    public async Task<IBiomaterial?> UpdateBiomaterialAsync(int id, IBiomaterial biomaterial)
    {
        return await unitOfWork.BiomaterialRepository.UpdateBiomaterialAsync(id, biomaterial);
    }

    public async Task<IBiomaterial?> DeleteBiomaterialAsync(int id)
    {
        return await unitOfWork.BiomaterialRepository.DeleteBiomaterialAsync(id);
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