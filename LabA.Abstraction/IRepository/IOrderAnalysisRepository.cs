using LabA.Abstraction.IModel;

namespace LabA.Abstraction.IRepository;

public interface IOrderAnalysisRepository
{
    public Task<IEnumerable<IOrderAnalysis>> GetAllOrderAnalysisAsync();
    public Task<IOrderAnalysis?> GetOrderAnalysisByIdAsync(int id);
    public Task<IOrderAnalysis> AddOrderAnalysisAsync(IOrderAnalysis orderAnalysis);
    public Task<IOrderAnalysis?> UpdateOrderAnalysisAsync(int id, IOrderAnalysis orderAnalysis);
    public Task<IOrderAnalysis?> DeleteOrderAnalysisAsync(int id);
}