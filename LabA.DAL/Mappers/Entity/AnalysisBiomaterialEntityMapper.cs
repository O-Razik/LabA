using LabA.Abstraction.IModel;
using LabA.DAL.Models;

namespace LabA.DAL.Mappers.Entity;

public static class AnalysisBiomaterialEntityMapper
{
    public static AnalysisBiomaterial MapToEntity(this IAnalysisBiomaterial analysisBiomaterial)
    {
        if (analysisBiomaterial == null)
        {
            throw new ArgumentNullException(nameof(analysisBiomaterial), "AnalysisBiomaterial cannot be null");
        }

        return new AnalysisBiomaterial
        {
            AnalysisBiomaterialId = analysisBiomaterial.AnalysisBiomaterialId,
            AnalysisId = analysisBiomaterial.AnalysisId,
            Analysis = analysisBiomaterial.Analysis?.MapToEntity(),
            BiomaterialId = analysisBiomaterial.BiomaterialId,
            Biomaterial = analysisBiomaterial.Biomaterial?.MapToEntity()
        };
    }

}