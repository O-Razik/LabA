using LabA.Abstraction.IModel;
using LabA.Abstraction.IRepository;
using LabA.DAL.Data;
using LabA.DAL.Mappers;
using LabA.DAL.Models;

namespace LabA.DAL.Repository;

using Microsoft.EntityFrameworkCore;

public class AnalysisResultRepository(LabAContext context) : IAnalysisResultRepository
{
    public async Task<IEnumerable<IAnalysisResult>> GetAllAnalysisResultsAsync()
    {
        var analysisResults = await context.AnalysisResults
            .Include(a => a.OrderAnalysis)
            .ToListAsync();
        return analysisResults.Cast<IAnalysisResult>().ToList();
    }

    public async Task<IAnalysisResult?> GetAnalysisResultAsync(int id)
    {
        return await context.AnalysisResults.FirstOrDefaultAsync(a => a.AnalysisResultId == id);
    }

    public async Task<IAnalysisResult> AddAnalysisResultAsync(IAnalysisResult analysisResult)
    {
        ArgumentNullException.ThrowIfNull(analysisResult, nameof(analysisResult));

        var entity = analysisResult.MapToEntity();
        await context.AnalysisResults.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<IAnalysisResult?> UpdateAnalysisResultAsync(int id, IAnalysisResult analysisResult)
    {
        ArgumentNullException.ThrowIfNull(analysisResult, nameof(analysisResult));

        var existingAnalysisResult = await context.AnalysisResults.FirstOrDefaultAsync(a => a.AnalysisResultId == id);
        if (existingAnalysisResult == null)
        {
            return null;
        }

        context.Entry(existingAnalysisResult).CurrentValues.SetValues(analysisResult);
        await context.SaveChangesAsync();

        return existingAnalysisResult;
    }

    public async Task<IAnalysisResult?> DeleteAnalysisResultAsync(int id)
    {
        var entity = await context.AnalysisResults.Where(a => a.AnalysisResultId == id).FirstOrDefaultAsync();

        if (entity == null)
        {
            return null;
        }

        context.AnalysisResults.Remove(entity);
        await context.SaveChangesAsync();

        return entity;
    }
}

