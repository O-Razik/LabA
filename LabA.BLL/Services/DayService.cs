using LabA.Abstraction.IModel;
using LabA.Abstraction.IRepository;
using LabA.Abstraction.IServices;

namespace LabA.BLL.Services;

public class DayService(IUnitOfWork unitOfWork) : IDayService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    
    public async Task<IEnumerable<IDay>> GetAllDaysAsync()
    {
        return await _unitOfWork.DayRepository.GetAllDaysAsync();
    }

    public async Task<IDay?> GetDayByIdAsync(int id)
    {
        return await _unitOfWork.DayRepository.GetDayByIdAsync(id);
    }

    public async Task<IDay> AddDayAsync(IDay day)
    {
        return await _unitOfWork.DayRepository.AddDayAsync(day);
    }

    public async Task<IDay?> UpdateDayAsync(int id, IDay day)
    {
        return await _unitOfWork.DayRepository.UpdateDayAsync(id, day);
    }

    public async Task<IDay?> DeleteDayAsync(int id)
    {
        return await _unitOfWork.DayRepository.DeleteDayAsync(id);
    }

    public void Validate(IDay day)
    {
        if (day == null)
        {
            throw new ArgumentNullException(nameof(day), "Day is null");
        }

        if (day.DayId < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(day.DayId), "Day id is less than 0");
        }

        if (string.IsNullOrWhiteSpace(day.DayName))
        {
            throw new ArgumentException("Day name is null or empty", nameof(day.DayName));
        }
    }
}