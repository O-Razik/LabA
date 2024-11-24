using LabA.Abstraction.IModel;
using LabA.Abstraction.IRepository;
using LabA.Abstraction.IServices;

namespace LabA.BLL.Services;

public class AnalysisBiomaterailService(IUnitOfWork unitOfWork) : IAnalysisBiomaterialService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<IEnumerable<IAnalysisBiomaterial>> GetAllAnalysisBiomaterialsAsync()
    {
        return await _unitOfWork.AnalysisBiomaterialRepository.GetAllAnalysisBiomaterialsAsync();
    }

    public async Task<IAnalysisBiomaterial?> GetAnalysisBiomaterialByIdAsync(int id)
    {
        return await _unitOfWork.AnalysisBiomaterialRepository.GetAnalysisBiomaterialByIdAsync(id);
    }

    public async Task<IAnalysisBiomaterial> AddAnalysisBiomaterialAsync(IAnalysisBiomaterial analysisBiomaterial)
    {
        return await _unitOfWork.AnalysisBiomaterialRepository.AddAnalysisBiomaterialAsync(analysisBiomaterial);
    }

    public async Task<IAnalysisBiomaterial?> UpdateAnalysisBiomaterialAsync(int id,
        IAnalysisBiomaterial analysisBiomaterial)
    {
        return await _unitOfWork.AnalysisBiomaterialRepository.UpdateAnalysisBiomaterialAsync(id, analysisBiomaterial);
    }

    public async Task<IAnalysisBiomaterial?> DeleteAnalysisBiomaterialAsync(int id)
    {
        return await _unitOfWork.AnalysisBiomaterialRepository.DeleteAnalysisBiomaterialAsync(id);
    }

    public void Validate(IAnalysisBiomaterial analysisBiomaterial)
    {
        if (analysisBiomaterial == null)
        {
            throw new ArgumentNullException(nameof(analysisBiomaterial));
        }

        if (analysisBiomaterial.AnalysisBiomaterialId < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(analysisBiomaterial.AnalysisBiomaterialId));
        }

        if (analysisBiomaterial.AnalysisId < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(analysisBiomaterial.AnalysisId));
        }

        if (analysisBiomaterial.BiomaterialId < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(analysisBiomaterial.BiomaterialId));
        }
    }
}