using LabA.Abstraction.DTO;
using LabA.Abstraction.IModel;
using LabA.Abstraction.IRepository;
using LabA.Abstraction.IServices;

namespace LabA.BLL.Services;

public class EmployeeService(IUnitOfWork unitOfWork) : IEmployeeService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<IEnumerable<IEmployee>> GetAllEmployeesAsync()
    {
        return await _unitOfWork.EmployeeRepository.GetAllEmployeesAsync();
    }

    public async Task<IEmployee?> GetEmployeeByIdAsync(int id)
    {
        return await _unitOfWork.EmployeeRepository.GetEmployeeByIdAsync(id);
    }

    public async Task<IEmployee> AddEmployeeAsync(IEmployee employee)
    {
        return await _unitOfWork.EmployeeRepository.AddEmployeeAsync(employee);
    }

    public async Task<IEmployee?> UpdateEmployeeAsync(int id, IEmployee employee)
    {
        return await _unitOfWork.EmployeeRepository.UpdateEmployeeAsync(id, employee);
    }

    public async Task<IEmployee?> DeleteEmployeeAsync(int id)
    {
        return await _unitOfWork.EmployeeRepository.DeleteEmployeeAsync(id);
    }

    public void Validate(IEmployee employee)
    {
        if (employee == null)
        {
            throw new ArgumentNullException(nameof(employee));
        }

        if (employee.EmployeeId < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(employee.EmployeeId));
        }

        if (string.IsNullOrWhiteSpace(employee.FirstName))
        {
            throw new ArgumentException("First name is required", nameof(employee.FirstName));
        }

        if (string.IsNullOrWhiteSpace(employee.LastName))
        {
            throw new ArgumentException("Last name is required", nameof(employee.LastName));
        }

        if (string.IsNullOrWhiteSpace(employee.Email))
        {
            throw new ArgumentException("Email is required", nameof(employee.Email));
        }

        if (string.IsNullOrWhiteSpace(employee.PhoneNumber))
        {
            throw new ArgumentException("Phone is required", nameof(employee.PhoneNumber));
        }

        if (employee.PositionId < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(employee.PositionId));
        }

        if (employee.LaboratoryId < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(employee.LaboratoryId));
        }
    }

    public Task<IEnumerable<IEmployee>> GetEmployeesByLaboratoryAsync(ILaboratory laboratory)
    {
        return _unitOfWork.EmployeeRepository.GetEmployeesByLaboratoryAsync(laboratory);
    }
}