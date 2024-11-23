using LabA.Abstraction.IModel;
using LabA.DAL.Models;

namespace LabA.DAL.Mappers;

public static class AnalysisBiomaterialEntityMapper
{
    public static AnalysisBiomaterial MapToEntity(this IAnalysisBiomaterial analysisBiomaterial)
    {
        return new AnalysisBiomaterial
        {
            AnalysisBiomaterialId = analysisBiomaterial.AnalysisBiomaterialId,
            AnalysisId = analysisBiomaterial.AnalysisId,
            BiomaterialId = analysisBiomaterial.BiomaterialId
        };
    }
}