using LabA.Abstraction.IModel;
using LabA.Abstraction.IRepository;
using LabA.Abstraction.IServices;

namespace LabA.BLL.Services;

public class SexService(IUnitOfWork unitOfWork) : ISexService
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<IEnumerable<ISex>> GetAllSexesAsync()
    {
        return await unitOfWork.SexRepository.GetAllSexesAsync();
    }

    public async Task<ISex?> GetSexByIdAsync(int id)
    {
        return await unitOfWork.SexRepository.GetSexByIdAsync(id);
    }

    public Task<ISex> AddSexAsync(ISex sex)
    {
        return unitOfWork.SexRepository.AddSexAsync(sex);
    }

    public Task<ISex?> UpdateSexAsync(int id, ISex sex)
    {
        return unitOfWork.SexRepository.UpdateSexAsync(id, sex);
    }

    public Task<ISex?> DeleteSexAsync(int id)
    {
        return unitOfWork.SexRepository.DeleteSexAsync(id);
    }

    public void Validate(ISex sex)
    {
        if (sex == null)
        {
            throw new ArgumentNullException(nameof(sex));
        }

        if (sex.SexId < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(sex.SexId));
        }
    }
}