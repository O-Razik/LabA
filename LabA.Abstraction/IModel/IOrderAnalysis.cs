namespace LabA.Abstraction.IModel;

public interface IOrderAnalysis
{
    public int OrderAnalysisId { get; set; }

    public int OrderId { get; set; }

    public int AnalysisId { get; set; }
}