using LabA.Abstraction.IModel;
using LabA.DAL.Models;

namespace LabA.DAL.Mappers;

public static class AnalysisResultEntityMapper
{
    public static AnalysisResult MapToEntity(this IAnalysisResult analysisResult)
    {
        return new AnalysisResult
        {
            AnalysisResultId = analysisResult.AnalysisResultId,
            OrderAnalysisId = analysisResult.OrderAnalysisId,
            Indicator = analysisResult.Indicator,
            ExecutionDate = analysisResult.ExecutionDate,
            Description = analysisResult.Description
        };
    }
}