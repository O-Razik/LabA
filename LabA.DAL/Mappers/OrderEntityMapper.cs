using LabA.Abstraction.IModel;
using LabA.DAL.Models;

namespace LabA.DAL.Mappers;

public static class OrderEntityMapper
{
    public static Order MapToEntity(this IOrder order)
    {
        return new Order
        {
            OrderId = order.OrderId,
            Number = order.Number,
            StatusId = order.StatusId,
            EmployeeId = order.EmployeeId,
            ClientId = order.ClientId,
            BiomaterialCollectionDate = order.BiomaterialCollectionDate,
            Fullprice = order.Fullprice,
        };
    }
}