using LabA.Abstraction.IModel;

namespace LabA.Abstraction.IRepository;

public interface ICityRepository
{
    public Task<IEnumerable<ICity>> GetAllCitiesAsync();
    public Task<ICity?> GetCityByIdAsync(int id);
    public Task<ICity> AddCityAsync(ICity city);
    public Task<ICity?> UpdateCityAsync(int id, ICity city);
    public Task<ICity?> DeleteCityAsync(int id);
}