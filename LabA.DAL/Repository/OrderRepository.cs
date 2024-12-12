using LabA.Abstraction.IModel;
using LabA.Abstraction.IRepository;
using LabA.DAL.Data;
using LabA.DAL.Mappers;
using LabA.DAL.Mappers.Entity;
using Microsoft.EntityFrameworkCore;

namespace LabA.DAL.Repository;

public class OrderRepository(LabAContext context) : IOrderRepository
{
    public async Task<IEnumerable<IOrder>> GetAllOrdersAsync()
    {
        var orders = await context.Orders.ToListAsync();
        return orders.Cast<IOrder>().ToList();
    }

    public async Task<IOrder?> GetOrderByIdAsync(int id)
    {
        return await context.Orders.Where(o => o.OrderId == id).FirstOrDefaultAsync();
    }

    public async Task<IOrder> AddOrderAsync(IOrder order)
    {
        ArgumentNullException.ThrowIfNull(order, nameof(order));

        var entity = order.MapToEntity();

        if (entity.Client != null)
        {
            context.Entry(entity.Client).State = EntityState.Unchanged;
        }

        if (entity.Employee != null)
        {
            context.Entry(entity.Employee).State = EntityState.Unchanged;
        }

        if (entity.Status != null)
        {
            context.Entry(entity.Status).State = EntityState.Unchanged;
        }

        // Safely get the maximum OrderId or default to 0 if there are no entries
        var index = await context.Orders.AnyAsync()
            ? await context.Orders.MaxAsync(o => o.OrderId)
            : 0;

        entity.OrderId = index + 1;
        await context.Orders.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<IOrder?> UpdateOrderAsync(int id, IOrder order)
    {
        ArgumentNullException.ThrowIfNull(order, nameof(order));

        var existingOrder = await context.Orders.FirstOrDefaultAsync(o => o.OrderId == id);
        if (existingOrder == null)
        {
            return null;
        }

        context.Entry(existingOrder).CurrentValues.SetValues(order);
        await context.SaveChangesAsync();

        return order;
    }

    public async Task<IOrder?> DeleteOrderAsync(int id)
    {
        var order = await context.Orders.Where(o => o.OrderId == id).FirstOrDefaultAsync();

        if (order == null)
        {
            return null;
        }

        context.Orders.Remove(order);
        await context.SaveChangesAsync();

        return order;
    }
}