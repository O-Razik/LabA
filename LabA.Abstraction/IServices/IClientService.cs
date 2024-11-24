using LabA.Abstraction.IModel;

namespace LabA.Abstraction.IServices;

public interface IClientService
{
    public Task<IEnumerable<IClient>> GetAllClientsAsync();
    public Task<IClient?> GetClientByIdAsync(int id);
    public Task<IClient> AddClientAsync(IClient client);
    public Task<IClient?> UpdateClientAsync(int id, IClient client);

    public Task<IClient?> DeleteClientAsync(int id);

    public void Validate(IClient client);
}