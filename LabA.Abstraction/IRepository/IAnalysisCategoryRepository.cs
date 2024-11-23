using LabA.Abstraction.IModel;

namespace LabA.Abstraction.IRepository;

public interface IAnalysisCategoryRepository
{
    public Task<IEnumerable<IAnalysisCategory>> GetAllAnalysisCategories();
    public Task<IAnalysisCategory?> GetAnalysisCategoryById(int id);
    public Task<IAnalysisCategory> AddAnalysisCategory(IAnalysisCategory analysisCategory);
    public Task<IAnalysisCategory?> UpdateAnalysisCategory(int id, IAnalysisCategory analysisCategory);
    public Task<IAnalysisCategory?> DeleteAnalysisCategory(int id);

}