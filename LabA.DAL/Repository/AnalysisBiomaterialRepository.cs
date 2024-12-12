using Microsoft.EntityFrameworkCore;
using LabA.Abstraction.IRepository;
using LabA.Abstraction.IModel;
using LabA.DAL.Data;
using LabA.DAL.Mappers;
using LabA.DAL.Mappers.Entity;

namespace LabA.DAL.Repository;

public class AnalysisBiomaterialRepository(LabAContext context) : IAnalysisBiomaterialRepository
{
    public async Task<IEnumerable<IAnalysisBiomaterial>> GetAllAnalysisBiomaterialsAsync()
    {
        var analysisBiomaterials = await context.AnalysisBiomaterials
            .Include(a => a.Analysis)
            .Include(a => a.Biomaterial)
            .ToListAsync();
        return analysisBiomaterials.Cast<IAnalysisBiomaterial>().ToList();
    }

    public async Task<IAnalysisBiomaterial?> GetAnalysisBiomaterialByIdAsync(int id)
    {
        var analysisBiomaterial = await context.AnalysisBiomaterials
            .Include(a => a.Analysis)
            .Include(a => a.Biomaterial)
            .FirstOrDefaultAsync(a => a.AnalysisBiomaterialId == id);
        return analysisBiomaterial;
    }

    public async Task<IAnalysisBiomaterial> AddAnalysisBiomaterialAsync(IAnalysisBiomaterial analysisBiomaterial)
    {
        ArgumentNullException.ThrowIfNull(analysisBiomaterial, nameof(analysisBiomaterial));

        var entity = analysisBiomaterial.MapToEntity();

        // Safely get the maximum AnalysisBiomaterialId or default to 0 if there are no entries
        var index = await context.AnalysisBiomaterials.AnyAsync()
            ? await context.AnalysisBiomaterials.MaxAsync(a => a.AnalysisBiomaterialId)
            : 0;

        entity.AnalysisBiomaterialId = index + 1;

        await context.AnalysisBiomaterials.AddAsync(entity);
        await context.SaveChangesAsync();

        return entity;
    }

    public async Task<IAnalysisBiomaterial?> UpdateAnalysisBiomaterialAsync(int id, IAnalysisBiomaterial analysisBiomaterial)
    {
        ArgumentNullException.ThrowIfNull(analysisBiomaterial, nameof(analysisBiomaterial));

        var existingAnalysisBiomaterial = await context.AnalysisBiomaterials
            .Include(a => a.Analysis)
            .Include(a => a.Biomaterial)
            .FirstOrDefaultAsync(a => a.AnalysisBiomaterialId == id);

        if (existingAnalysisBiomaterial == null)
        {
            return null;
        }

        context.Entry(existingAnalysisBiomaterial).CurrentValues.SetValues(analysisBiomaterial);
        await context.SaveChangesAsync();

        return existingAnalysisBiomaterial;
    }

    public async Task<IAnalysisBiomaterial?> DeleteAnalysisBiomaterialAsync(int id)
    {
        var analysisBiomaterial = await context.AnalysisBiomaterials
            .FirstOrDefaultAsync(a => a.AnalysisBiomaterialId == id);

        if (analysisBiomaterial == null)
        {
            return null;
        }

        context.AnalysisBiomaterials.Remove(analysisBiomaterial);
        await context.SaveChangesAsync();

        return analysisBiomaterial;
    }
}
