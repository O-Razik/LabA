﻿using Microsoft.EntityFrameworkCore;
using LabA.Abstraction.IRepository;
using LabA.Abstraction.IModel;
using LabA.DAL.Data;
using LabA.DAL.Mappers;
using LabA.DAL.Mappers.Entity;

namespace LabA.DAL.Repository;

public class AnalysisCategoryRepository(LabAContext context) : IAnalysisCategoryRepository
{
    public async Task<IEnumerable<IAnalysisCategory>> GetAllAnalysisCategories()
    {
        var analysisCategories = await context.AnalysisCategories.ToListAsync();
        return analysisCategories.Cast<IAnalysisCategory>().ToList();
    }

    public async Task<IAnalysisCategory?> GetAnalysisCategoryById(int id)
    {
        return await context.AnalysisCategories.FirstOrDefaultAsync(c => c.AnalysisCategoryId == id);
    }

    public async Task<IAnalysisCategory> AddAnalysisCategory(IAnalysisCategory analysisCategory)
    {
        ArgumentNullException.ThrowIfNull(analysisCategory);

        var entity = analysisCategory.MapToEntity();

        // Safely get the maximum AnalysisCategoryId or default to 0 if there are no entries
        var index = await context.AnalysisCategories.AnyAsync()
            ? await context.AnalysisCategories.MaxAsync(c => c.AnalysisCategoryId)
            : 0;

        entity.AnalysisCategoryId = index + 1;

        await context.AnalysisCategories.AddAsync(entity);
        await context.SaveChangesAsync();

        return entity;
    }


    public async Task<IAnalysisCategory?> UpdateAnalysisCategory(int id, IAnalysisCategory analysisCategory)
    {
        ArgumentNullException.ThrowIfNull(analysisCategory);

        var existingAnalysisCategory = await context.AnalysisCategories.FirstOrDefaultAsync(c => c.AnalysisCategoryId == id);
        if (existingAnalysisCategory == null)
        {
            return null;
        }

        context.Entry(existingAnalysisCategory).CurrentValues.SetValues(analysisCategory);
        await context.SaveChangesAsync();
        return existingAnalysisCategory;
    }

    public async Task<IAnalysisCategory?> DeleteAnalysisCategory(int id)
    {
        var analysisCategory = await context.AnalysisCategories.FirstOrDefaultAsync(c => c.AnalysisCategoryId == id);
        if (analysisCategory == null)
        {
            return null;
        }

        context.AnalysisCategories.Remove(analysisCategory);
        await context.SaveChangesAsync();
        return analysisCategory;
    }
}
