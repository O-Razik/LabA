using LabA.Abstraction.IModel;
using LabA.Abstraction.IRepository;
using LabA.DAL.Data;
using LabA.DAL.Mappers;
using Microsoft.EntityFrameworkCore;

namespace LabA.DAL.Repository;

public class LaboratoryRepository(LabAContext context) : ILaboratoryRepository
{
    public async Task<IEnumerable<ILaboratory>> GetAllLaboratoriesAsync()
    {
        var laboratories = await context.Laboratories
            .Include(l => l.City)
            .ToListAsync();
        return laboratories.Cast<ILaboratory>().ToList();
    }

    public async Task<ILaboratory?> GetLaboratoryByIdAsync(int id)
    {
        return await context.Laboratories.Where(l => l.LaboratoryId == id)
            .Include(l => l.City)
            .FirstOrDefaultAsync();
    }

    public async Task<ILaboratory> AddLaboratoryAsync(ILaboratory laboratory)
    {
        ArgumentNullException.ThrowIfNull(laboratory, nameof(laboratory));

        var entity = laboratory.MapToEntity();
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
}