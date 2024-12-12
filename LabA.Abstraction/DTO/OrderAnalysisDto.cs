namespace LabA.Abstraction.DTO;

public class OrderAnalysisDto
{
    public int OrderAnalysisId { get; set; }

    public int OrderId { get; set; }

    public AnalysisDto Analysis { get; set; }
}