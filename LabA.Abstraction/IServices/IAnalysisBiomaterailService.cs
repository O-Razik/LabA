using LabA.Abstraction.IModel;

namespace LabA.Abstraction.IServices;

public interface IAnalysisBiomaterailService
{
    Task<IEnumerable<IAnalysisBiomaterial>> GetAllAnalysisBiomaterialsAsync();
    Task<IAnalysisBiomaterial?> GetAnalysisBiomaterialByIdAsync(int id);
    Task<IAnalysisBiomaterial> AddAnalysisBiomaterialAsync(IAnalysisBiomaterial analysisBiomaterial);
    Task<IAnalysisBiomaterial?> UpdateAnalysisBiomaterialAsync(int id, IAnalysisBiomaterial analysisBiomaterial);
    Task<IAnalysisBiomaterial?> DeleteAnalysisBiomaterialAsync(int id);
}