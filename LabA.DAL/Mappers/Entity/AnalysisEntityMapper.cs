using LabA.Abstraction.IModel;
using LabA.DAL.Models;

namespace LabA.DAL.Mappers.Entity;

public static class AnalysisEntityMapper
{
    public static Analysis MapToEntity(this IAnalysis analysis)
    {
        if (analysis == null)
        {
            throw new ArgumentNullException(nameof(analysis), "Analysis cannot be null");
        }

        return new Analysis
        {
            AnalysisId = analysis.AnalysisId,
            Name = analysis.Name,
            CategoryId = analysis.CategoryId,
            Price = analysis.Price,
            Description = analysis.Description,
            Category = analysis.Category.MapToEntity(),
            AnalysisBiomaterials = analysis.AnalysisBiomaterials.Select(ab => ab.MapToEntity()).ToList()
        };
    }

}