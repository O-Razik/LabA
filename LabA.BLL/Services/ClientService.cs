using LabA.Abstraction.IModel;
using LabA.Abstraction.IRepository;
using LabA.Abstraction.IServices;

namespace LabA.BLL.Services;

public class ClientService(IUnitOfWork unitOfWork) : IClientService
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<IEnumerable<IClient>> GetAllClientsAsync()
    {
        return await unitOfWork.ClientRepository.GetAllClientsAsync();
    }

    public async Task<IClient?> GetClientByIdAsync(int id)
    {
        return await unitOfWork.ClientRepository.GetClientByIdAsync(id);
    }

    public async Task<IClient> AddClientAsync(IClient client)
    {
        return await unitOfWork.ClientRepository.AddClientAsync(client);
    }

    public async Task<IClient?> UpdateClientAsync(int id, IClient client)
    {
        return await unitOfWork.ClientRepository.UpdateClientAsync(id, client);
    }

    public async Task<IClient?> DeleteClientAsync(int id)
    {
        return await unitOfWork.ClientRepository.DeleteClientAsync(id);
    }

    public void Validate(IClient client)
    {
        if (client == null)
        {
            throw new ArgumentNullException(nameof(client));
        }

        if (client.ClientId < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(client.ClientId));
        }

        if (string.IsNullOrWhiteSpace(client.FirstName))
        {
            throw new ArgumentException("First name is required", nameof(client.FirstName));
        }

        if (string.IsNullOrWhiteSpace(client.LastName))
        {
            throw new ArgumentException("Last name is required", nameof(client.LastName));
        }

        if (string.IsNullOrWhiteSpace(client.Email))
        {
            throw new ArgumentException("Email is required", nameof(client.Email));
        }

        if (string.IsNullOrWhiteSpace(client.PhoneNumber))
        {
            throw new ArgumentException("Phone is required", nameof(client.PhoneNumber));
        }

        if (client.SexId < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(client.SexId));
        }
    }
}