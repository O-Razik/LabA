using LabA.Abstraction.IModel;
using LabA.Abstraction.IRepository;
using LabA.DAL.Data;
using LabA.DAL.Mappers;
using Microsoft.EntityFrameworkCore;

namespace LabA.DAL.Repository;

public class BiomaterialRepository(LabAContext context) : IBiomaterialRepository
{
    public async Task<IEnumerable<IBiomaterial>> GetAllBiomaterialsAsync()
    {
        var biomaterials = await context.Biomaterials.ToListAsync();
        return biomaterials.Cast<IBiomaterial>().ToList();
    }

    public async Task<IBiomaterial?> GetBiomateralAsync(int id)
    {
        return await context.Biomaterials.FirstOrDefaultAsync(b => b.BiomaterialId == id);
    }

    public async Task<IBiomaterial> AddBiomaterialAsync(IBiomaterial biomaterial)
    {
        ArgumentNullException.ThrowIfNull(biomaterial, nameof(biomaterial));

        var entity = biomaterial.MapToEntity();
        context.Biomaterials.Add(entity);
        await context.SaveChangesAsync();

        return entity;
    }

    public async Task<IBiomaterial?> UpdateBiomaterialAsync(int id, IBiomaterial biomaterial)
    {
        ArgumentNullException.ThrowIfNull(biomaterial, nameof(biomaterial));

        var existingBiomaterial = await context.Biomaterials.FirstOrDefaultAsync(b => b.BiomaterialId == id);
        if (existingBiomaterial == null)
        {
            return null;
        }

        context.Entry(existingBiomaterial).CurrentValues.SetValues(biomaterial);
        await context.SaveChangesAsync();

        return existingBiomaterial;
    }

    public async Task<IBiomaterial?> DeleteBiomaterialAsync(int id)
    {
        var entity = await context.Biomaterials.FirstOrDefaultAsync(b => b.BiomaterialId == id);

        if (entity == null)
        {
            return null;
        }

        context.Biomaterials.Remove(entity);
        await context.SaveChangesAsync();

        return entity;
    }
}