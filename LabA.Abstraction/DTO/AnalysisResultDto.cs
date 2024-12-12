namespace LabA.Abstraction.DTO;

public class AnalysisResultDto
{
    public int AnalysisResultId { get; set; }

    public OrderAnalysisDto OrderAnalysis { get; set; }

    public int Indicator { get; set; }

    public DateTime ExecutionDate { get; set; }

    public string Description { get; set; }
}