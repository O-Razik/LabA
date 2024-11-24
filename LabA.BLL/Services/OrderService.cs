using LabA.Abstraction.IModel;
using LabA.Abstraction.IRepository;
using LabA.Abstraction.IServices;

namespace LabA.BLL.Services;

public class OrderService(IUnitOfWork unitOfWork) : IOrderService
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<IEnumerable<IOrder>> GetAllOrdersAsync()
    {
        return await unitOfWork.OrderRepository.GetAllOrdersAsync();
    }

    public async Task<IOrder?> GetOrderByIdAsync(int id)
    {
        return await unitOfWork.OrderRepository.GetOrderByIdAsync(id);
    }

    public async Task<IOrder> AddOrderAsync(IOrder order)
    {
        return await unitOfWork.OrderRepository.AddOrderAsync(order);
    }

    public async Task<IOrder?> UpdateOrderAsync(int id, IOrder order)
    {
        return await unitOfWork.OrderRepository.UpdateOrderAsync(id, order);
    }

    public async Task<IOrder?> DeleteOrderAsync(int id)
    {
        return await unitOfWork.OrderRepository.DeleteOrderAsync(id);
    }

    public void Validate(IOrder order)
    {
        if (order == null)
        {
            throw new ArgumentNullException(nameof(order));
        }

        if (order.OrderId < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(order.OrderId));
        }

        if (order.ClientId <= 0)
        {
            throw new ArgumentException("Customer ID must be greater than 0", nameof(order.ClientId));
        }

        if (order.EmployeeId <= 0)
        {
            throw new ArgumentException("Employee ID must be greater than 0", nameof(order.EmployeeId));
        }
    }
}