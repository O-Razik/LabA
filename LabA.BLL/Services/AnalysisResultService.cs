using LabA.Abstraction.IModel;
using LabA.Abstraction.IRepository;
using LabA.Abstraction.IServices;

namespace LabA.BLL.Services;

public class AnalysisResultService(IUnitOfWork unitOfWork) : IAnalysisResultService
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<IEnumerable<IAnalysisResult>> GetAllAnalysisResultsAsync()
    {
        return await unitOfWork.AnalysisResultRepository.GetAllAnalysisResultsAsync();
    }

    public async Task<IAnalysisResult?> GetAnalysisResultAsync(int id)
    {
        return await unitOfWork.AnalysisResultRepository.GetAnalysisResultAsync(id);
    }

    public async Task<IAnalysisResult> AddAnalysisResultAsync(IAnalysisResult analysisResult)
    {
        return await unitOfWork.AnalysisResultRepository.AddAnalysisResultAsync(analysisResult);
    }

    public async Task<IAnalysisResult?> UpdateAnalysisResultAsync(int id, IAnalysisResult analysisResult)
    {
        return await unitOfWork.AnalysisResultRepository.UpdateAnalysisResultAsync(id, analysisResult);
    }

    public async Task<IAnalysisResult?> DeleteAnalysisResultAsync(int id)
    {
        return await unitOfWork.AnalysisResultRepository.DeleteAnalysisResultAsync(id);
    }

    public void Validate(IAnalysisResult analysisResult)
    {
        if (analysisResult == null)
        {
            throw new ArgumentNullException(nameof(analysisResult));
        }

        if (analysisResult.AnalysisResultId < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(analysisResult.AnalysisResultId));
        }

        if (analysisResult.OrderAnalysisId < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(analysisResult.OrderAnalysisId));
        }

        if (analysisResult.Indicator < 0)
        {
            throw new ArgumentNullException(nameof(analysisResult.Indicator));
        }

        if (analysisResult.Description.Length == 0)
        {
            throw new ArgumentException(nameof(analysisResult.Description));
        }
    }
}