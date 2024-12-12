using LabA.Abstraction.IModel;
using LabA.DAL.Models;

namespace LabA.DAL.Mappers.Entity;

public static class AnalysisCategoryEntityMapper
{
    public static AnalysisCategory MapToEntity(this IAnalysisCategory analysisCategory)
    {
        return new AnalysisCategory
        {
            AnalysisCategoryId = analysisCategory.AnalysisCategoryId,
            CategoryName = analysisCategory.CategoryName
        };
    }
}