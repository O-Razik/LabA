using LabA.Abstraction.IModel;
using LabA.DAL.Models;

namespace LabA.DAL.Mappers;

public static class LaboratoryScheduleEntityMapper
{
    public static LaboratorySchedule MapToEntity(this ILaboratorySchedule laboratorySchedule)
    {
        return new LaboratorySchedule
        {
            LaboratoryScheduleId = laboratorySchedule.LaboratoryScheduleId,
            LaboratoryId = laboratorySchedule.LaboratoryId,
            ScheduleId = laboratorySchedule.ScheduleId
        };
    }
}