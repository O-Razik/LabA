using LabA.Abstraction.IModel;
using LabA.Abstraction.IRepository;
using LabA.DAL.Data;
using LabA.DAL.Mappers;
using LabA.DAL.Mappers.Entity;
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
}