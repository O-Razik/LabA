using LabA.Abstraction.IModel;
using LabA.Abstraction.IRepository;
using LabA.DAL.Data;
using LabA.DAL.Mappers;
using LabA.DAL.Mappers.Entity;
using Microsoft.EntityFrameworkCore;

namespace LabA.DAL.Repository;

public class ClientRepository(LabAContext context) : IClientRepository
{
    public async Task<IEnumerable<IClient>> GetAllClientsAsync()
    {
        var clients = await context.Clients
            .Include(c => c.Sex)
            .ToListAsync();
        return clients.Cast<IClient>().ToList();
    }

    public async Task<IClient?> GetClientByIdAsync(int id)
    {
        return await context.Clients.Where(c => c.ClientId == id)
            .Include(c => c.Sex)
            .FirstOrDefaultAsync();
    }

    public async Task<IClient> AddClientAsync(IClient client)
    {
        ArgumentNullException.ThrowIfNull(client, nameof(client));

        var entity = client.MapToEntity();

        if (entity.Sex != null)
        {
            context.Entry(entity.Sex).State = EntityState.Unchanged;
        }

        await context.Clients.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<IClient?> UpdateClientAsync(int id, IClient client)
    {
        ArgumentNullException.ThrowIfNull(client, nameof(client));

        var existingClient = await context.Clients
            .Include(c => c.Sex)
            .FirstOrDefaultAsync(c => c.ClientId == id);
        if (existingClient == null)
        {
            return null;
        }

        context.Entry(existingClient).CurrentValues.SetValues(client);
        await context.SaveChangesAsync();

        return client;
    }

    public async Task<IClient?> DeleteClientAsync(int id)
    {
        var client = await context.Clients.Where(c => c.ClientId == id).FirstOrDefaultAsync();

        if (client == null)
        {
            return null;
        }

        context.Clients.Remove(client);
        await context.SaveChangesAsync();

        return client;
    }
}