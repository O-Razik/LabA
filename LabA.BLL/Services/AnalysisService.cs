using LabA.Abstraction.IModel;
using LabA.Abstraction.IRepository;
using LabA.Abstraction.IServices;

namespace LabA.BLL.Services;

public class AnalysisService(IUnitOfWork unitOfWork) : IAnalysisService
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<IEnumerable<IAnalysis>> GetAllAnalysisAsync()
    {
        return await unitOfWork.AnalysisRepository.GetAllAnalysisAsync();
    }

    public async Task<IAnalysis?> GetAnalysisByIdAsync(int id)
    {
        return await unitOfWork.AnalysisRepository.GetAnalysisByIdAsync(id);
    }

    public async Task<IAnalysis> AddAnalysisAsync(IAnalysis analysis)
    {
        return await unitOfWork.AnalysisRepository.AddAnalysisAsync(analysis);
    }

    public async Task<IAnalysis?> UpdateAnalysisAsync(int id, IAnalysis analysis)
    {
        return await unitOfWork.AnalysisRepository.UpdateAnalysisAsync(id, analysis);
    }

    public async Task<IAnalysis?> DeleteAnalysisAsync(int id)
    {
        return await unitOfWork.AnalysisRepository.DeleteAnalysisAsync(id);
    }

    public void Validate(IAnalysis analysis)
    {
        if (analysis == null)
        {
            throw new ArgumentNullException(nameof(analysis));
        }

        if (string.IsNullOrWhiteSpace(analysis.Name))
        {
            throw new ArgumentException("Analysis name cannot be null or empty", nameof(analysis.Name));
        }

        if (analysis.Price <= 0)
        {
            throw new ArgumentException("Analysis price cannot be less than or equal to zero", nameof(analysis.Price));
        }
    }
}