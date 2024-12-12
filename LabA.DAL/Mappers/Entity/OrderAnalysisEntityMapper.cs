using LabA.Abstraction.IModel;
using LabA.DAL.Models;

namespace LabA.DAL.Mappers.Entity;

public static class OrderAnalysisEntityMapper
{
    public static OrderAnalysis MapToEntity(this IOrderAnalysis orderAnalysis)
    {
        return new OrderAnalysis
        {
            OrderAnalysisId = orderAnalysis.OrderAnalysisId,
            OrderId = orderAnalysis.OrderId,
            AnalysisId = orderAnalysis.AnalysisId,
        };
    }
}