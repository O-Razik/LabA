using LabA.Abstraction.IModel;
using LabA.Abstraction.IRepository;
using LabA.DAL.Data;
using LabA.DAL.Mappers;
using LabA.DAL.Mappers.Entity;
using Microsoft.EntityFrameworkCore;

namespace LabA.DAL.Repository;

public class AnalysisRepository(LabAContext context) : IAnalysisRepository
{
    public async Task<IEnumerable<IAnalysis>> GetAllAnalysisAsync()
    {
        var analysis = await context.Analyses
            .Include(a => a.Category)
            .Include(a => a.AnalysisBiomaterials).ThenInclude(ab => ab.Biomaterial)
            .ToListAsync();
        return analysis.Cast<IAnalysis>().ToList();
    }

    public async Task<IEnumerable<IAnalysis>> GetAnalysisFilteredAsync(string? name, string? categoryName, double? price)
    {
        var query = context.Analyses
            .Include(a => a.Category)
            .Include(a => a.AnalysisBiomaterials).ThenInclude(ab => ab.Biomaterial)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(name))
        {
            query = query.Where(a => a.Name.Contains(name));
        }

        if (!string.IsNullOrWhiteSpace(categoryName))
        {
            query = query.Where(a => a.Category.CategoryName.Contains(categoryName));
        }

        if (price.HasValue)
        {
            query = query.Where(a => a.Price < price);
        }

        return await query.ToListAsync();
    }

    public async Task<IAnalysis?> GetAnalysisByIdAsync(int id)
    {
        return await context.Analyses.Where(a => a.AnalysisId == id)
            .Include(a => a.Category)
            .Include(a => a.AnalysisBiomaterials).ThenInclude(ab => ab.Biomaterial)
            .FirstOrDefaultAsync();
    }

    public async Task<IAnalysis?> GetAnalysisByNameAsync(string name)
    {
        return await context.Analyses.Where(a => a.Name == name)
            .Include(a => a.Category)
            .Include(a => a.AnalysisBiomaterials).ThenInclude(ab => ab.Biomaterial)
            .FirstOrDefaultAsync();
    }

    public async Task<IAnalysis> AddAnalysisAsync(IAnalysis analysis)
    {
        ArgumentNullException.ThrowIfNull(analysis, nameof(analysis));

        // Map the IAnalysis to your entity
        var entity = analysis.MapToEntity();

        // Ensure the existing Category is attached to the context, so it won't be saved again
        if (entity.Category != null)
        {
            context.Entry(entity.Category).State = EntityState.Unchanged;
        }

        // Handle existing Biomaterials in AnalysisBiomaterials
        foreach (var ab in entity.AnalysisBiomaterials)
        {
            if (ab.Biomaterial != null)
            {
                context.Entry(ab.Biomaterial).State = EntityState.Unchanged; // Mark Biomaterial as Unchanged
            }
        }

        // Add the new Analysis to the context
        await context.Analyses.AddAsync(entity);

        // Save the changes
        await context.SaveChangesAsync();

        return entity;
    }


    public async Task<IAnalysis?> UpdateAnalysisAsync(int id, IAnalysis analysis)
    {
        ArgumentNullException.ThrowIfNull(analysis, nameof(analysis));

        var entity = analysis.MapToEntity();
        var existingAnalysis = await context.Analyses
            .Include(a => a.Category)
            .Include(a => a.AnalysisBiomaterials).ThenInclude(ab => ab.Biomaterial)
            .FirstOrDefaultAsync(a => a.AnalysisId == id);

        if (existingAnalysis == null)
        {
            return null;
        }

        context.Entry(existingAnalysis).CurrentValues.SetValues(entity);
        await context.SaveChangesAsync();

        return existingAnalysis;
    }

    public async Task<IAnalysis?> DeleteAnalysisAsync(int id)
    {
        var analysis = await context.Analyses.Where(a => a.AnalysisId == id).FirstOrDefaultAsync();

        if (analysis == null)
        {
            return null;
        }

        // Remove related AnalysisBiomaterial records
        context.AnalysisBiomaterials.RemoveRange(analysis.AnalysisBiomaterials);

        context.Analyses.Remove(analysis);
        await context.SaveChangesAsync();

        return analysis;
    }
}