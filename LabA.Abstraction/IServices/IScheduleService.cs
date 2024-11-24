using LabA.Abstraction.IModel;

namespace LabA.Abstraction.IServices;

public interface IScheduleService
{
    public Task<IEnumerable<ISchedule>> GetAllSchedulesAsync();
    public Task<ISchedule?> GetScheduleByIdAsync(int id);
    public Task<ISchedule> AddScheduleAsync(ISchedule schedule);
    public Task<ISchedule?> UpdateScheduleAsync(int id, ISchedule schedule);
    public Task<ISchedule?> DeleteScheduleAsync(int id);

    public void Validate(ISchedule schedule);
}