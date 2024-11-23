namespace LabA.Abstraction.IModel;

public interface IEmployee
{
    public int EmployeeId { get; set; }

    public int PositionId { get; set; }

    public int LaboratoryId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }
}