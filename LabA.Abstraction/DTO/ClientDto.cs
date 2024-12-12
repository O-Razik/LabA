namespace LabA.Abstraction.DTO;

public class ClientDto
{
    public int ClientId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public SexDto Sex { get; set; }

    public DateOnly Birthdate { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }
}