using LabA.Abstraction.IModel;
using LabA.DAL.Models;

namespace LabA.DAL.Mappers.Entity;

public static class PositionEntityMapper
{
    public static Position MapToEntity(this IPosition position)
    {
        return new Position
        {
            PositionId = position.PositionId,
            PositionName = position.PositionName
        };
    }
}