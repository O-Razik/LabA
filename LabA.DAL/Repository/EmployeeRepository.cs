using LabA.Abstraction.DTO;
using LabA.Abstraction.IModel;
using LabA.Abstraction.IRepository;
using LabA.DAL.Data;
using LabA.DAL.Mappers;
using LabA.DAL.Mappers.Entity;
using Microsoft.EntityFrameworkCore;

namespace LabA.DAL.Repository;

public class EmployeeRepository(LabAContext context) : IEmployeeRepository
{
    public async Task<IEnumerable<IEmployee>> GetAllEmployeesAsync()
    {
        var employees = await context.Employees
            .Include(e => e.Laboratory)
            .Include(e => e.Position)
            .ToListAsync();
        return employees.Cast<IEmployee>().ToList();
    }

    public async Task<IEmployee?> GetEmployeeByIdAsync(int id)
    {
        return await context.Employees.Where(e => e.EmployeeId == id)
            .Include(e => e.Laboratory)
            .Include(e => e.Position)
            .FirstOrDefaultAsync();
    }

    public async Task<IEmployee> AddEmployeeAsync(IEmployee employee)
    {
        ArgumentNullException.ThrowIfNull(employee, nameof(employee));

        var entity = employee.MapToEntity();

        if (entity.Position != null)
        {
            context.Entry(entity.Position).State = EntityState.Unchanged;
        }

        await context.Employees.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<IEmployee?> UpdateEmployeeAsync(int id, IEmployee employee)
    {
        ArgumentNullException.ThrowIfNull(employee, nameof(employee));

        var existingEmployee = await context.Employees
            .Include(e => e.Laboratory)
            .Include(e => e.Position)
            .FirstOrDefaultAsync(e => e.EmployeeId == id);
        if (existingEmployee == null)
        {
            return null;
        }

        context.Entry(existingEmployee).CurrentValues.SetValues(employee);
        await context.SaveChangesAsync();

        return employee;
    }

    public async Task<IEmployee?> DeleteEmployeeAsync(int id)
    {
        var employee = await context.Employees.Where(e => e.EmployeeId == id).FirstOrDefaultAsync();

        if (employee == null)
        {
            return null;
        }

        context.Employees.Remove(employee);
        await context.SaveChangesAsync();

        return employee;
    }

    public async Task<IEnumerable<IEmployee>> GetEmployeesByLaboratoryAsync(ILaboratory laboratory)
    {
        var employees = await context.Employees
            .Include(e => e.Laboratory)
            .Include(e => e.Position)
            .Where(e => e.LaboratoryId == laboratory.LaboratoryId)
            .ToListAsync();

        return employees.ToList();
    }
}