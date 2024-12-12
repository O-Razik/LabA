using LabA.Abstraction.IModel;
using LabA.Abstraction.IRepository;
using LabA.Abstraction.IServices;

namespace LabA.BLL.Services;

public class LaboratoryService(IUnitOfWork unitOfWork) : ILaboratoryService
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<IEnumerable<ILaboratory>> GetAllLaboratoriesAsync()
    {
        return await unitOfWork.LaboratoryRepository.GetAllLaboratoriesAsync();
    }

    public async Task<ILaboratory?> GetLaboratoryByIdAsync(int id)
    {
        return await unitOfWork.LaboratoryRepository.GetLaboratoryByIdAsync(id);
    }

    public async Task<ILaboratory> AddLaboratoryAsync(ILaboratory laboratory)
    {
        return await unitOfWork.LaboratoryRepository.AddLaboratoryAsync(laboratory);
    }

    public async Task<ILaboratory?> UpdateLaboratoryAsync(int id, ILaboratory laboratory)
    {
        return await unitOfWork.LaboratoryRepository.UpdateLaboratoryAsync(id, laboratory);
    }

    public async Task<ILaboratory?> DeleteLaboratoryAsync(int id)
    {
        return await unitOfWork.LaboratoryRepository.DeleteLaboratoryAsync(id);
    }

    public Task<IEnumerable<ILaboratory>> GetLaboratoriesByCityAsync(int id)
    {
        return unitOfWork.LaboratoryRepository.GetLaboratoriesByCityAsync(id);
    }

    public void Validate(ILaboratory laboratory)
    {
        if (laboratory == null)
        {
            throw new ArgumentNullException(nameof(laboratory));
        }

        if (string.IsNullOrWhiteSpace(laboratory.Address))
        {
            throw new ArgumentException("Laboratory address cannot be empty", nameof(laboratory.Address));
        }

        if (laboratory.Address.Length > 1000)
        {
            throw new ArgumentException("Laboratory address cannot be longer than 1000 characters", nameof(laboratory.Address));
        }

        if (string.IsNullOrWhiteSpace(laboratory.PhoneNumber))
        {
            throw new ArgumentException("Laboratory phone cannot be empty", nameof(laboratory.PhoneNumber));
        }

        if (laboratory.PhoneNumber.Length > 50)
        {
            throw new ArgumentException("Laboratory phone cannot be longer than 50 characters", nameof(laboratory.PhoneNumber));
        }

        if (laboratory.CityId < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(laboratory.CityId));
        }

        if (laboratory.LaboratoryId < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(laboratory.LaboratoryId));
        }
    }
}