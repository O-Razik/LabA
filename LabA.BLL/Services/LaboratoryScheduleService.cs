using LabA.Abstraction.IModel;
using LabA.Abstraction.IRepository;
using LabA.Abstraction.IServices;

namespace LabA.BLL.Services;

public class LaboratoryScheduleService(IUnitOfWork unitOfWork) : ILaboratoryScheduleService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<IEnumerable<ILaboratorySchedule>> GetAllLaboratorySchedulesAsync()
    {
        return await _unitOfWork.LaboratoryScheduleRepository.GetAllLaboratorySchedulesAsync();
    }

    public async Task<ILaboratorySchedule?> GetLaboratoryScheduleByIdAsync(int id)
    {
        return await _unitOfWork.LaboratoryScheduleRepository.GetLaboratoryScheduleByIdAsync(id);
    }

    public async Task<ILaboratorySchedule> AddLaboratoryScheduleAsync(ILaboratorySchedule laboratorySchedule)
    {
        return await _unitOfWork.LaboratoryScheduleRepository.AddLaboratoryScheduleAsync(laboratorySchedule);
    }

    public async Task<ILaboratorySchedule?> UpdateLaboratoryScheduleAsync(int id, ILaboratorySchedule laboratorySchedule)
    {
        return await _unitOfWork.LaboratoryScheduleRepository.UpdateLaboratoryScheduleAsync(id, laboratorySchedule);
    }

    public async Task<ILaboratorySchedule?> DeleteLaboratoryScheduleAsync(int id)
    {
        return await _unitOfWork.LaboratoryScheduleRepository.DeleteLaboratoryScheduleAsync(id);
    }

    public void Validate(ILaboratorySchedule laboratorySchedule)
    {
        if (laboratorySchedule == null)
        {
            throw new ArgumentNullException(nameof(laboratorySchedule));
        }

        if (laboratorySchedule.LaboratoryScheduleId < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(laboratorySchedule.LaboratoryScheduleId));
        }

        if (laboratorySchedule.LaboratoryId < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(laboratorySchedule.LaboratoryId));
        }

        if (laboratorySchedule.ScheduleId < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(laboratorySchedule.ScheduleId));
        }
    }
}