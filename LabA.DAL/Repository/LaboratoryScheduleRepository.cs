using LabA.Abstraction.IModel;
using LabA.Abstraction.IRepository;
using LabA.DAL.Data;
using LabA.DAL.Mappers;
using LabA.DAL.Mappers.Entity;
using Microsoft.EntityFrameworkCore;

namespace LabA.DAL.Repository;

public class LaboratoryScheduleRepository(LabAContext context) : ILaboratoryScheduleRepository
{
    public async Task<IEnumerable<ILaboratorySchedule>> GetAllLaboratorySchedulesAsync()
    {
        var laboratorySchedules = await context.LaboratorySchedules
            .Include(s => s.Laboratory)
            .Include(s => s.Schedule)
            .ToListAsync();
        return laboratorySchedules.Cast<ILaboratorySchedule>().ToList();
    }

    public async Task<ILaboratorySchedule?> GetLaboratoryScheduleByIdAsync(int id)
    {
        return await context.LaboratorySchedules.Where(s => s.LaboratoryScheduleId == id)
            .Include(s => s.Laboratory)
            .Include(s => s.Schedule)
            .FirstOrDefaultAsync();
    }

    public async Task<ILaboratorySchedule> AddLaboratoryScheduleAsync(ILaboratorySchedule laboratorySchedule)
    {
        ArgumentNullException.ThrowIfNull(laboratorySchedule, nameof(laboratorySchedule));

        var entity = laboratorySchedule.MapToEntity();
        await context.LaboratorySchedules.AddAsync(entity);

        // Safely get the maximum LaboratoryScheduleId or default to 0 if there are no entries
        var index = await context.LaboratorySchedules.AnyAsync()
            ? await context.LaboratorySchedules.MaxAsync(s => s.LaboratoryScheduleId)
            : 0;

        entity.LaboratoryScheduleId = index + 1;
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<ILaboratorySchedule?> UpdateLaboratoryScheduleAsync(int id, ILaboratorySchedule laboratorySchedule)
    {
        ArgumentNullException.ThrowIfNull(laboratorySchedule, nameof(laboratorySchedule));

        var existingLaboratorySchedule = await context.LaboratorySchedules
            .Include(s => s.Laboratory)
            .Include(s => s.Schedule)
            .FirstOrDefaultAsync(s => s.LaboratoryScheduleId == id);
        if (existingLaboratorySchedule == null)
        {
            return null;
        }

        context.Entry(existingLaboratorySchedule).CurrentValues.SetValues(laboratorySchedule);
        await context.SaveChangesAsync();

        return laboratorySchedule;
    }

    public async Task<ILaboratorySchedule?> DeleteLaboratoryScheduleAsync(int id)
    {
        var laboratorySchedule = await context.LaboratorySchedules.Where(s => s.LaboratoryScheduleId == id).FirstOrDefaultAsync();

        if (laboratorySchedule == null)
        {
            return null;
        }

        context.LaboratorySchedules.Remove(laboratorySchedule);
        await context.SaveChangesAsync();

        return laboratorySchedule;
    }
}