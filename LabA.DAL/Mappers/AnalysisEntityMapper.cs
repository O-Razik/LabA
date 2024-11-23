using LabA.Abstraction.IModel;
using LabA.DAL.Models;

namespace LabA.DAL.Mappers;

public static class AnalysisEntityMapper
{
    public static Analysis MapToEntity(this IAnalysis analysis)
    {
        return new Analysis
        {
            AnalysisId = analysis.AnalysisId,
            Name = analysis.Name,
            CategoryId = analysis.CategoryId,
            Price = analysis.Price,
            Description = analysis.Description
        };
    }
}