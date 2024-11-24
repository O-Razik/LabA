using LabA.Abstraction.IModel;
using LabA.Abstraction.IRepository;
using LabA.Abstraction.IServices;

namespace LabA.BLL.Services;

public class OrderAnalysisService(IUnitOfWork unitOfWork) : IOrderAnalysisService
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<IEnumerable<IOrderAnalysis>> GetAllOrderAnalysisAsync()
    {
        return await unitOfWork.OrderAnalysisRepository.GetAllOrderAnalysisAsync();
    }

    public async Task<IOrderAnalysis?> GetOrderAnalysisByIdAsync(int id)
    {
        return await unitOfWork.OrderAnalysisRepository.GetOrderAnalysisByIdAsync(id);
    }

    public async Task<IOrderAnalysis> AddOrderAnalysisAsync(IOrderAnalysis orderAnalysis)
    {
        return await unitOfWork.OrderAnalysisRepository.AddOrderAnalysisAsync(orderAnalysis);
    }

    public async Task<IOrderAnalysis?> UpdateOrderAnalysisAsync(int id, IOrderAnalysis orderAnalysis)
    {
        return await unitOfWork.OrderAnalysisRepository.UpdateOrderAnalysisAsync(id, orderAnalysis);
    }

    public async Task<IOrderAnalysis?> DeleteOrderAnalysisAsync(int id)
    {
        return await unitOfWork.OrderAnalysisRepository.DeleteOrderAnalysisAsync(id);
    }

    public void Validate(IOrderAnalysis orderAnalysis)
    {
        if (orderAnalysis == null)
        {
            throw new ArgumentNullException(nameof(orderAnalysis));
        }

        if (orderAnalysis.OrderAnalysisId < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(orderAnalysis.OrderAnalysisId));
        }

        if (orderAnalysis.OrderId < 0)
        {
            throw new ArgumentException("Order Id must be greater than 0", nameof(orderAnalysis.OrderId));
        }

        if (orderAnalysis.AnalysisId < 0)
        {
            throw new ArgumentException("Analysis Id must be greater than 0", nameof(orderAnalysis.AnalysisId));
        }
    }
}