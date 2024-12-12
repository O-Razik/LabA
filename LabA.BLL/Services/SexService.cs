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