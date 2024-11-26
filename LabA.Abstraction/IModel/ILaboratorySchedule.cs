namespace LabA.Abstraction.IModel;

public interface ILaboratorySchedule
{
    public int LaboratoryScheduleId { get; set; }

    public int LaboratoryId { get; set; }

    public int ScheduleId { get; set; }

    public ILaboratory Laboratory { get; set; }

    public ISchedule Schedule { get; set; }
}