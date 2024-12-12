using LabA.Abstraction.IModel;
using LabA.Abstraction.IRepository;
using LabA.DAL.Data;
using LabA.DAL.Mappers;
using LabA.DAL.Mappers.Entity;
using Microsoft.EntityFrameworkCore;

namespace LabA.DAL.Repository;

public class LaboratoryRepository(LabAContext context) : ILaboratoryRepository
{
    public async Task<IEnumerable<ILaboratory>> GetAllLaboratoriesAsync()
    {
        var laboratories = await context.Laboratories
            .Include(l => l.City)
            .Include(l => l.LaboratorySchedules).ThenInclude(ls => ls.Schedule).ThenInclude(s => s.Day) // Day is null
            .Include(l => l.Employees).ThenInclude(e => e.Position)
            .ToListAsync();
        return laboratories.Cast<ILaboratory>().ToList();
    }

    public async Task<ILaboratory?> GetLaboratoryByIdAsync(int id)
    {
        return await context.Laboratories.Where(l => l.LaboratoryId == id)
            .Include(l => l.City)
            .Include(l => l.LaboratorySchedules).ThenInclude(ls => ls.Schedule).ThenInclude(s => s.Day)
            .Include(l => l.Employees).ThenInclude(e => e.Position)
            .FirstOrDefaultAsync();
    }

    public async Task<ILaboratory> AddLaboratoryAsync(ILaboratory laboratory)
    {
        ArgumentNullException.ThrowIfNull(laboratory, nameof(laboratory));

        var entity = laboratory.MapToEntity();

        if (entity.City != null)
        {
            context.Entry(entity.City).State = EntityState.Unchanged;
        }
        foreach (var ls in entity.LaboratorySchedules)
        {
            if (ls.Schedule != null)
            {
                context.Entry(ls.Schedule).State = EntityState.Unchanged;
            }
        }

        // Safely get the maximum AnalysisCategoryId or default to 0 if there are no entries
        var index = await context.Laboratories.AnyAsync()
            ? await context.Laboratories.MaxAsync(l => l.LaboratoryId)
            : 0;

        entity.LaboratoryId = index + 1;

        await context.Laboratories.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<ILaboratory?> UpdateLaboratoryAsync(int id, ILaboratory laboratory)
    {
        ArgumentNullException.ThrowIfNull(laboratory, nameof(laboratory));

        var existingLaboratory = await context.Laboratories
            .Include(l => l.City)
            .FirstOrDefaultAsync(l => l.LaboratoryId == id);
        if (existingLaboratory == null)
        {
            return null;
        }

        context.Entry(existingLaboratory).CurrentValues.SetValues(laboratory);
        await context.SaveChangesAsync();

        return laboratory;
    }

    public async Task<ILaboratory?> DeleteLaboratoryAsync(int id)
    {
        var laboratory = await context.Laboratories.Where(l => l.LaboratoryId == id).FirstOrDefaultAsync();

        if (laboratory == null)
        {
            return null;
        }

        context.Laboratories.Remove(laboratory);
        await context.SaveChangesAsync();

        return laboratory;
    }

    public async Task<IEnumerable<ILaboratory>> GetLaboratoriesByCityAsync(int id)
    {
        var laboratories = await context.Laboratories
            .Include(l => l.City)
            .Include(l => l.LaboratorySchedules).ThenInclude(ls => ls.Schedule).ThenInclude(s => s.Day)
            .Include(l => l.Employees).ThenInclude(e => e.Position)
            .Where(l => l.CityId == id)
            .ToListAsync();

        return laboratories.ToList();
    }
}