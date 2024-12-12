using LabA.Abstraction.IModel;
using LabA.DAL.Models;

namespace LabA.DAL.Mappers.Entity;

public static class EmployeeEntityMapper
{
    public static Employee MapToEntity(this IEmployee employee)
    {
        return new Employee
        {
            EmployeeId = employee.EmployeeId,
            PositionId = employee.PositionId,
            Position = employee.Position.MapToEntity(),
            LaboratoryId = employee.LaboratoryId,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            PhoneNumber = employee.PhoneNumber,
            Email = employee.Email
        };
    }
}