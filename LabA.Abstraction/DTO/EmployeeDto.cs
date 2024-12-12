namespace LabA.Abstraction.DTO;

public class EmployeeDto
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }

    public PositionDto Position { get; set; }

    public int LaboratoryId { get; set; }
}