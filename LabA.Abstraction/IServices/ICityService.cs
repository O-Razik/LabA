using LabA.Abstraction.IModel;

namespace LabA.Abstraction.IServices;

public interface ICityService
{
    public Task<IEnumerable<ICity>> GetAllCitiesAsync();
    public Task<ICity?> GetCityByIdAsync(int id);
    public Task<ICity> AddCityAsync(ICity city);
    public Task<ICity?> UpdateCityAsync(int id, ICity city);
    public Task<ICity?> DeleteCityAsync(int id);
}