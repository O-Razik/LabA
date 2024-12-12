using Microsoft.EntityFrameworkCore;
using LabA.Abstraction.IRepository;
using LabA.Abstraction.IModel;
using LabA.DAL.Data;
using LabA.DAL.Mappers.Entity;

namespace LabA.DAL.Repository;

public class StatusRepository(LabAContext context) : IStatusRepository
{
    public async Task<IEnumerable<IStatus>> GetAllStatusesAsync()
    {
        var statuses = await context.Statuses.ToListAsync();
        return statuses.Cast<IStatus>().ToList();
    }

    public async Task<IStatus?> GetStatusByIdAsync(int id)
    {
        return await context.Statuses.Where(s => s.StatusId == id).FirstOrDefaultAsync();
    }

    public async Task<IStatus> AddStatusAsync(IStatus status)
    {
        ArgumentNullException.ThrowIfNull(status, nameof(status));

        var entity = status.MapToEntity();

        // Safely get the maximum StatusId or default to 0 if there are no entries
        var index = await context.Statuses.AnyAsync()
            ? await context.Statuses.MaxAsync(s => s.StatusId)
            : 0;

        entity.StatusId = index + 1;
        await context.Statuses.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<IStatus?> UpdateStatusAsync(int id, IStatus status)
    {
        ArgumentNullException.ThrowIfNull(status, nameof(status));

        var existingStatus = await context.Statuses.FirstOrDefaultAsync(s => s.StatusId == id);
        if (existingStatus == null)
        {
            return null;
        }

        context.Entry(existingStatus).CurrentValues.SetValues(status);
        await context.SaveChangesAsync();

        return status;
    }


    public async Task<IStatus?> DeleteStatusAsync(int id)
    {
        var status = await context.Statuses.Where(s => s.StatusId == id).FirstOrDefaultAsync();

        if (status == null)
        {
            return null;
        }

        context.Statuses.Remove(status);
        await context.SaveChangesAsync();

        return status;
    }

}