using LabA.Abstraction.IModel;

namespace LabA.Abstraction.IRepository;

public interface IDayRepository
{
    public Task<IEnumerable<IDay>> GetAllDaysAsync();
    public Task<IDay?> GetDayByIdAsync(int id);
    public Task<IDay> AddDayAsync(IDay day);
    public Task<IDay?> UpdateDayAsync(int id, IDay day);
    public Task<IDay?> DeleteDayAsync(int id);
}