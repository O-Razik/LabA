using LabA.Abstraction.IModel;
using LabA.DAL.Models;

namespace LabA.DAL.Mappers.Entity;

public static class LaboratoryScheduleEntityMapper
{
    public static LaboratorySchedule MapToEntity(this ILaboratorySchedule laboratorySchedule)
    {
        return new LaboratorySchedule
        {
            LaboratoryScheduleId = laboratorySchedule.LaboratoryScheduleId,
            LaboratoryId = laboratorySchedule.LaboratoryId,
            Laboratory = laboratorySchedule.Laboratory?.MapToEntity(),
            ScheduleId = laboratorySchedule.ScheduleId,
            Schedule = laboratorySchedule.Schedule?.MapToEntity()
        };
    }
}