namespace LabA.Abstraction.DTO;

public class ScheduleDto
{
    public int ScheduleId { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public TimeOnly CollectionEndTime { get; set; }

    public DayDto Day { get; set; }
}