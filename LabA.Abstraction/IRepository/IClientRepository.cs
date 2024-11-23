using LabA.Abstraction.IModel;

namespace LabA.Abstraction.IRepository;

public interface IClientRepository
{
    public Task<IEnumerable<IClient>> GetAllClientsAsync();
    public Task<IClient?> GetClientByIdAsync(int id);
    public Task<IClient> AddClientAsync(IClient client);
    public Task<IClient?> UpdateClientAsync(int id, IClient client);

    public Task<IClient?> DeleteClientAsync(int id);
}