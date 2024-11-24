using LabA.Abstraction.IModel;

namespace LabA.Abstraction.IServices;

public interface IAnalysisService
{
    Task<IEnumerable<IAnalysis>> GetAllAnalysisAsync();
    Task<IAnalysis?> GetAnalysisByIdAsync(int id);
    Task<IAnalysis> AddAnalysisAsync(IAnalysis analysis);
    Task<IAnalysis?> UpdateAnalysisAsync(int id,IAnalysis analysis);
    Task<IAnalysis?> DeleteAnalysisAsync(int id);

    void Validate(IAnalysis analysis);
}