using LabA.Abstraction.IModel;

namespace LabA.Abstraction.IRepository;

public interface IDayRepository
{
    public Task<IEnumerable<IDay>> GetAllDaysAsync();
    public Task<IDay?> GetDayByIdAsync(int id);
}