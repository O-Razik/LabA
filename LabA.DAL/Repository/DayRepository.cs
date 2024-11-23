using LabA.Abstraction.IModel;
using LabA.Abstraction.IRepository;
using LabA.DAL.Data;
using LabA.DAL.Mappers;
using Microsoft.EntityFrameworkCore;

namespace LabA.DAL.Repository;

public class DayRepository(LabAContext context) : IDayRepository
{
    public async Task<IEnumerable<IDay>> GetAllDaysAsync()
    {
        var days = await context.Days.ToListAsync();
        return days.Cast<IDay>().ToList();
    }

    public async Task<IDay?> GetDayByIdAsync(int id)
    {
        return await context.Days.Where(d => d.DayId == id).FirstOrDefaultAsync();
    }

    public async Task<IDay> AddDayAsync(IDay day)
    {
        ArgumentNullException.ThrowIfNull(day, nameof(day));

        var entity = day.MapToEntity();
        await context.Days.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<IDay?> UpdateDayAsync(int id, IDay? day)
    {
        ArgumentNullException.ThrowIfNull(day, nameof(day));

        var existingDay = await context.Days.FirstOrDefaultAsync(d => d.DayId == id);
        if (existingDay == null)
        {
            return null;
        }

        context.Entry(existingDay).CurrentValues.SetValues(day);
        await context.SaveChangesAsync();
        return day;
    }

    public async Task<IDay?> DeleteDayAsync(int id)
    {
        var day = await context.Days.Where(d => d.DayId == id).FirstOrDefaultAsync();

        if (day == null)
        {
            return null;
        }

        context.Days.Remove(day);
        await context.SaveChangesAsync();
        return day;
    }
}