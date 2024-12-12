using LabA.Abstraction.IModel;
using LabA.DAL.Models;

namespace LabA.DAL.Mappers.Entity;

public static class DayEntityMapper
{
    public static Day MapToEntity(this IDay day)
    {
        return new Day
        {
            DayId = day.DayId,
            DayName = day.DayName
        };
    }
}