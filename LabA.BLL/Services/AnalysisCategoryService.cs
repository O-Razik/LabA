using LabA.Abstraction.IModel;
using LabA.Abstraction.IRepository;
using LabA.Abstraction.IServices;

namespace LabA.BLL.Services;

public class AnalysisCategoryService(IUnitOfWork unitOfWork) : IAnalysisCategoryService
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<IEnumerable<IAnalysisCategory>> GetAllAnalysisCategories()
    {
        return await unitOfWork.AnalysisCategoryRepository.GetAllAnalysisCategories();
    }

    public async Task<IAnalysisCategory?> GetAnalysisCategoryById(int id)
    {
        return await unitOfWork.AnalysisCategoryRepository.GetAnalysisCategoryById(id);
    }

    public async Task<IAnalysisCategory> AddAnalysisCategory(IAnalysisCategory analysisCategory)
    {
        return await unitOfWork.AnalysisCategoryRepository.AddAnalysisCategory(analysisCategory);
    }

    public async Task<IAnalysisCategory?> UpdateAnalysisCategory(int id, IAnalysisCategory analysisCategory)
    {
        return await unitOfWork.AnalysisCategoryRepository.UpdateAnalysisCategory(id, analysisCategory);
    }

    public async Task<IAnalysisCategory?> DeleteAnalysisCategory(int id)
    {
        return await unitOfWork.AnalysisCategoryRepository.DeleteAnalysisCategory(id);
    }

    public void Validate(IAnalysisCategory analysisCategory)
    {
        if (analysisCategory.AnalysisCategoryId < 0)
        {
            throw new Exception("Analysis category ID is invalid");
        }
        if (analysisCategory == null)
        {
            throw new Exception("Analysis category is null");
        }
        if (analysisCategory.CategoryName.Length == 0)
        {
            throw new Exception("Category name is empty");
        }
        if (analysisCategory.CategoryName.Length > 100)
        {
            throw new Exception("Category name is too long");
        }
    }
}