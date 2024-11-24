using LabA.Abstraction.IModel;

namespace LabA.Abstraction.IServices;

public interface ILaboratoryScheduleService
{
    public Task<IEnumerable<ILaboratorySchedule>> GetAllLaboratorySchedulesAsync();
    public Task<ILaboratorySchedule?> GetLaboratoryScheduleByIdAsync(int id);
    public Task<ILaboratorySchedule> AddLaboratoryScheduleAsync(ILaboratorySchedule laboratorySchedule);
    public Task<ILaboratorySchedule?> UpdateLaboratoryScheduleAsync(int id, ILaboratorySchedule laboratorySchedule);
    public Task<ILaboratorySchedule?> DeleteLaboratoryScheduleAsync(int id);
}