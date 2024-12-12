using LabA.Abstraction.IModel;

namespace LabA.Abstraction.DTO;

public class AnalysisDto
{
    public int AnalysisId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double? Price { get; set; }
    public AnalysisCategoryDto Category { get; set; }
    public ICollection<AnalysisBiomaterialDto> AnalysisBiomaterial { get; set; }
}