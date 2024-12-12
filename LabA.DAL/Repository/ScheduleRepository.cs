using LabA.Abstraction.IModel;
using LabA.Abstraction.IRepository;
using LabA.DAL.Data;
using LabA.DAL.Mappers;
using LabA.DAL.Mappers.Entity;
using Microsoft.EntityFrameworkCore;

namespace LabA.DAL.Repository;

public class ScheduleRepository(LabAContext context) : IScheduleRepository
{
    public async Task<IEnumerable<ISchedule>> GetAllSchedulesAsync()
    {
        var schedules = await context.Schedules
            .Include(s => s.Day)
            .ToListAsync();
        return schedules.Cast<ISchedule>().ToList();
    }

    public async Task<ISchedule?> GetScheduleByIdAsync(int id)
    {
        return await context.Schedules
            .Include(s => s.Day)
            .FirstOrDefaultAsync(s => s.ScheduleId == id);
    }

    public async Task<ISchedule> AddScheduleAsync(ISchedule schedule)
    {
        ArgumentNullException.ThrowIfNull(schedule, nameof(schedule));

        var entity = schedule.MapToEntity();

        if (entity.Day != null)
        {
            context.Entry(entity.Day).State = EntityState.Unchanged;
        }

        await context.Schedules.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<ISchedule?> UpdateScheduleAsync(int id, ISchedule schedule)
    {
        ArgumentNullException.ThrowIfNull(schedule, nameof(schedule));

        var existingSchedule = await context.Schedules.FirstOrDefaultAsync(s => s.ScheduleId == id);
        if (existingSchedule == null)
        {
            return null;
        }

        context.Entry(existingSchedule).CurrentValues.SetValues(schedule);
        await context.SaveChangesAsync();

        return schedule;
    }

    public async Task<ISchedule?> DeleteScheduleAsync(int id)
    {
        var schedule = await context.Schedules.Where(s => s.ScheduleId == id).FirstOrDefaultAsync();

        if (schedule == null)
        {
            return null;
        }

        context.Schedules.Remove(schedule);
        await context.SaveChangesAsync();

        return schedule;
    }

}