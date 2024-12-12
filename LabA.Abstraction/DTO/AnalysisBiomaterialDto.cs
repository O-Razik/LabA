namespace LabA.Abstraction.DTO;

public class AnalysisBiomaterialDto
{
    public int AnalysisBiomaterialId { get; set; }

    public int AnalysisId { get; set; }
    public BiomaterialDto Biomaterial { get; set; }
}