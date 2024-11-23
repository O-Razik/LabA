using LabA.Abstraction.IModel;
using LabA.Abstraction.IRepository;
using LabA.DAL.Data;
using LabA.DAL.Mappers;
using Microsoft.EntityFrameworkCore;


namespace LabA.DAL.Repository;

public class OrderAnalysisRepository(LabAContext context) : IOrderAnalysisRepository
{
    public async Task<IEnumerable<IOrderAnalysis>> GetAllOrderAnalysisAsync()
    {
        var orderAnalyses = await context.OrderAnalyses
            .Include(o => o.Order)
            .Include(o => o.Analysis)
            .ToListAsync();
        return orderAnalyses.Cast<IOrderAnalysis>().ToList();
    }

    public async Task<IOrderAnalysis?> GetOrderAnalysisByIdAsync(int id)
    {
        return await context.OrderAnalyses.Where(o => o.OrderAnalysisId == id)
            .Include(o => o.Order)
            .Include(o => o.Analysis)
            .FirstOrDefaultAsync();
    }


    public async Task<IOrderAnalysis> AddOrderAnalysisAsync(IOrderAnalysis orderAnalysis)
    {
        ArgumentNullException.ThrowIfNull(orderAnalysis, nameof(orderAnalysis));

        var entity = orderAnalysis.MapToEntity();
        await context.OrderAnalyses.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }


    public async Task<IOrderAnalysis?> UpdateOrderAnalysisAsync(int id, IOrderAnalysis orderAnalysis)
    {
        ArgumentNullException.ThrowIfNull(orderAnalysis, nameof(orderAnalysis));

        var existingOrderAnalysis = await context.OrderAnalyses
            .Include(o => o.Order)
            .Include(o => o.Analysis)
            .FirstOrDefaultAsync(o => o.OrderAnalysisId == id);
        if (existingOrderAnalysis == null)
        {
            return null;
        }

        context.Entry(existingOrderAnalysis).CurrentValues.SetValues(orderAnalysis);
        await context.SaveChangesAsync();

        return orderAnalysis;
    }

    public async Task<IOrderAnalysis?> DeleteOrderAnalysisAsync(int id)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        var orderAnalysis = await context.OrderAnalyses.Where(o => o.OrderAnalysisId == id).FirstOrDefaultAsync();

        if (orderAnalysis == null)
        {
            return null;
        }

        context.OrderAnalyses.Remove(orderAnalysis);
        await context.SaveChangesAsync();

        return orderAnalysis;
    }
}