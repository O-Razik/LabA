using LabA.Abstraction.IModel;
using LabA.Abstraction.IRepository;
using LabA.Abstraction.IServices;

namespace LabA.BLL.Services;

public class ScheduleService(IUnitOfWork unitOfWork) : IScheduleService
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<IEnumerable<ISchedule>> GetAllSchedulesAsync()
    {
        return await unitOfWork.ScheduleRepository.GetAllSchedulesAsync();
    }

    public async Task<ISchedule?> GetScheduleByIdAsync(int id)
    {
        return await unitOfWork.ScheduleRepository.GetScheduleByIdAsync(id);
    }

    public async Task<ISchedule> AddScheduleAsync(ISchedule schedule)
    {
        return await unitOfWork.ScheduleRepository.AddScheduleAsync(schedule);
    }

    public async Task<ISchedule?> UpdateScheduleAsync(int id, ISchedule schedule)
    {
        return await unitOfWork.ScheduleRepository.UpdateScheduleAsync(id, schedule);
    }

    public async Task<ISchedule?> DeleteScheduleAsync(int id)
    {
        return await unitOfWork.ScheduleRepository.DeleteScheduleAsync(id);
    }

    public void Validate(ISchedule schedule)
    {
        if (schedule == null)
        {
            throw new ArgumentNullException(nameof(schedule));
        }

        if (schedule.ScheduleId < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(schedule.ScheduleId));
        }
    }
}