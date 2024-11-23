namespace LabA.Abstraction.IModel;

public interface IAnalysis
{
    public int AnalysisId { get; set; }

    public string Name { get; set; }

    public int CategoryId { get; set; }

    public string Description { get; set; }
    
    public double? Price { get; set; }
}