using LabA.Abstraction.IModel;
using LabA.DAL.Models;

namespace LabA.DAL.Mappers.Entity;

public static class StatusEntityMapper
{
    public static Status MapToEntity(this IStatus status)
    {
        return new Status
        {
            StatusId = status.StatusId,
            StatusName = status.StatusName
        };
    }
}