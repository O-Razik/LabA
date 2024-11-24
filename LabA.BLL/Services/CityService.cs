using LabA.Abstraction.IModel;
using LabA.Abstraction.IRepository;
using LabA.Abstraction.IServices;

namespace LabA.BLL.Services;

public class CityService(IUnitOfWork unitOfWork) : ICityService
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<IEnumerable<ICity>> GetAllCitiesAsync()
    {
        return await unitOfWork.CityRepository.GetAllCitiesAsync();
    }

    public async Task<ICity?> GetCityByIdAsync(int id)
    {
        return await unitOfWork.CityRepository.GetCityByIdAsync(id);
    }

    public async Task<ICity> AddCityAsync(ICity city)
    {
        return await unitOfWork.CityRepository.AddCityAsync(city);
    }

    public async Task<ICity?> UpdateCityAsync(int id, ICity city)
    {
        return await unitOfWork.CityRepository.UpdateCityAsync(id, city);
    }

    public async Task<ICity?> DeleteCityAsync(int id)
    {
        return await unitOfWork.CityRepository.DeleteCityAsync(id);
    }

    public void Validate(ICity city)
    {
        if (city == null)
        {
            throw new ArgumentNullException(nameof(city));
        }
        if (city.CityId < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(city.CityId));
        }
        if (string.IsNullOrWhiteSpace(city.CityName))
        {
            throw new ArgumentException("City name is required", nameof(city.CityName));
        }
    }
}