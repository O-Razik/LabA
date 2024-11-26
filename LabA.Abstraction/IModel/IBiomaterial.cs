namespace LabA.Abstraction.IModel;

public interface IBiomaterial
{
    public int BiomaterialId { get; set; }

    public string BiomaterialName { get; set; }

    public ICollection<IAnalysisBiomaterial> AnalysisBiomaterials { get; set; }
}