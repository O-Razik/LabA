namespace LabA.Abstraction.IModel;

public interface IAnalysisResult
{
    public int AnalysisResultId { get; set; }

    public int OrderAnalysisId { get; set; }

    public int Indicator { get; set; }

    public DateTime ExecutionDate { get; set; }

    public string Description { get; set; }
}