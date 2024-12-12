using LabA.Abstraction.IModel;
using LabA.DAL.Models;

namespace LabA.DAL.Mappers.Entity;

public static class ClientEntityMapper
{
    public static Client MapToEntity(this IClient client)
    {
        return new Client
        {
            ClientId = client.ClientId,
            FirstName = client.FirstName,
            LastName = client.LastName,
            SexId = client.SexId,
            Birthdate = client.Birthdate,
            PhoneNumber = client.PhoneNumber,
            Email = client.Email
        };
    }
}