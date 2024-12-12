using LabA.Abstraction.IModel;

namespace LabA.Abstraction.IRepository;

public interface IAnalysisRepository
{
    Task<IEnumerable<IAnalysis>> GetAllAnalysisAsync();
    Task<IEnumerable<IAnalysis>> GetAnalysisFilteredAsync(string? name, string? categoryName, double? price);
    Task<IAnalysis?> GetAnalysisByIdAsync(int id);
    Task<IAnalysis?> GetAnalysisByNameAsync(string name);
    Task<IAnalysis> AddAnalysisAsync(IAnalysis analysis);
    Task<IAnalysis?> UpdateAnalysisAsync(int id,IAnalysis analysis);
    Task<IAnalysis?> DeleteAnalysisAsync(int id);
}