using LabA.Abstraction.IModel;
using LabA.Abstraction.IRepository;
using LabA.DAL.Data;
using LabA.DAL.Mappers;
using Microsoft.EntityFrameworkCore;

namespace LabA.DAL.Repository;

public class AnalysisRepository(LabAContext context) : IAnalysisRepository
{
    public async Task<IEnumerable<IAnalysis>> GetAllAnalysisAsync()
    {
        var analysis = await context.Analyses
            .Include(a => a.Category)
            .ToListAsync();
        return analysis.Cast<IAnalysis>().ToList();
    }

    public async Task<IAnalysis?> GetAnalysisByIdAsync(int id)
    {
        return await context.Analyses.Where(a => a.AnalysisId == id)
            .Include(a => a.Category)
            .FirstOrDefaultAsync();
    }

    public async Task<IAnalysis> AddAnalysisAsync(IAnalysis analysis)
    {
        ArgumentNullException.ThrowIfNull(analysis, nameof(analysis));

        var entity = analysis.MapToEntity();
        await context.Analyses.AddAsync(entity);
        await context.SaveChangesAsync();

        return entity;
    }

    public async Task<IAnalysis?> UpdateAnalysisAsync(int id, IAnalysis analysis)
    {
        ArgumentNullException.ThrowIfNull(analysis, nameof(analysis));

        var entity = analysis.MapToEntity();
        var existingAnalysis = await context.Analyses
            .Include(a => a.Category)
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

        context.Analyses.Remove(analysis);
        await context.SaveChangesAsync();

        return analysis;
    }
}