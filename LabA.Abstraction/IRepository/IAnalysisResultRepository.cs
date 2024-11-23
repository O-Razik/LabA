using LabA.Abstraction.IModel;

namespace LabA.Abstraction.IRepository;

public interface IAnalysisResultRepository
{
    public Task<IEnumerable<IAnalysisResult>> GetAllAnalysisResultsAsync();
    public Task<IAnalysisResult?> GetAnalysisResultAsync(int id);
    public Task<IAnalysisResult> AddAnalysisResultAsync(IAnalysisResult analysisResult);
    public Task<IAnalysisResult?> UpdateAnalysisResultAsync(int id, IAnalysisResult analysisResult);
    public Task<IAnalysisResult?> DeleteAnalysisResultAsync(int id);
}