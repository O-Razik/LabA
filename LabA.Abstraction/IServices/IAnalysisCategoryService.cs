using LabA.Abstraction.IModel;

namespace LabA.Abstraction.IServices;

public interface IAnalysisCategoryService
{
    public Task<IEnumerable<IAnalysisCategory>> GetAllAnalysisCategories();
    public Task<IAnalysisCategory?> GetAnalysisCategoryById(int id);
    public Task<IAnalysisCategory> AddAnalysisCategory(IAnalysisCategory analysisCategory);
    public Task<IAnalysisCategory?> UpdateAnalysisCategory(int id, IAnalysisCategory analysisCategory);
    public Task<IAnalysisCategory?> DeleteAnalysisCategory(int id);

    public void Validate(IAnalysisCategory analysisCategory);

}