using LabA.Abstraction.IModel;
using LabA.DAL.Models;

namespace LabA.DAL.Mappers;

public static class ScheduleEntityMapper
{
    public static Schedule MapToEntity(this ISchedule schedule)
    {
        return new Schedule
        {
            ScheduleId = schedule.ScheduleId,
            DayId = schedule.DayId,
            StartTime = schedule.StartTime,
            EndTime = schedule.EndTime,
            CollectionEndTime = schedule.CollectionEndTime
        };
    }
}