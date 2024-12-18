﻿using LabA.Abstraction.DTO;
using LabA.Abstraction.IModel;

namespace LabA.Abstraction.IRepository;

public interface IEmployeeRepository
{
    public Task<IEnumerable<IEmployee>> GetAllEmployeesAsync();
    public Task<IEmployee?> GetEmployeeByIdAsync(int id);
    public Task<IEmployee> AddEmployeeAsync(IEmployee employee);
    public Task<IEmployee?> UpdateEmployeeAsync(int id, IEmployee employee);
    public Task<IEmployee?> DeleteEmployeeAsync(int id);
    Task<IEnumerable<IEmployee>> GetEmployeesByLaboratoryAsync(ILaboratory laboratory);
}