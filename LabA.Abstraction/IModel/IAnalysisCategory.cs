namespace LabA.Abstraction.IModel;

public interface IAnalysisCategory
{
    public int AnalysisCategoryId { get; set; }

    public string CategoryName { get; set; }

    public ICollection<IAnalysis> Analyses { get; set; }
}