namespace LabA.Abstraction.IModel;

public interface ISchedule
{
    public int ScheduleId { get; set; }

    public int DayId { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public TimeOnly CollectionEndTime { get; set; }
}