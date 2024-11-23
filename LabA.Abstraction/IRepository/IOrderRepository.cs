using LabA.Abstraction.IModel;

namespace LabA.Abstraction.IRepository;

public interface IOrderRepository
{
    public Task<IEnumerable<IOrder>> GetAllOrdersAsync();
    public Task<IOrder?> GetOrderByIdAsync(int id);
    public Task<IOrder> AddOrderAsync(IOrder order);
    public Task<IOrder?> UpdateOrderAsync(int id, IOrder order);
    public Task<IOrder?> DeleteOrderAsync(int id);
}