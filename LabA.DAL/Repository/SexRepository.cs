using LabA.Abstraction.IModel;
using LabA.Abstraction.IRepository;
using LabA.DAL.Data;
using LabA.DAL.Mappers;
using LabA.DAL.Models;
using Microsoft.EntityFrameworkCore;


namespace LabA.DAL.Repository;

public class SexRepository(LabAContext context) : ISexRepository
{
    public async Task<IEnumerable<ISex>> GetAllSexesAsync()
    {
        var sexes = await context.Sexes.ToListAsync();
        return sexes.Cast<ISex>().ToList();
    }

    public async Task<ISex?> GetSexById(int id)
    {
        return await context.Sexes.Where(s => s.SexId == id).FirstOrDefaultAsync();
    }

    public async Task<ISex> AddSexAsync(ISex sex)
    {
        ArgumentNullException.ThrowIfNull(sex, nameof(sex));

        var entity = sex.MapToEntity();
        await context.Sexes.AddAsync(entity);
        await context.SaveChangesAsync();

        return entity;
    }

    public async Task<ISex?> UpdateSexAsync(int id, ISex sex)
    {
        ArgumentNullException.ThrowIfNull(sex, nameof(sex));

        var existingSex = await context.Sexes.FirstOrDefaultAsync(a => a.SexId == id);
        if (existingSex == null)
        {
            return null;
        }

        context.Entry(existingSex).CurrentValues.SetValues(sex);
        await context.SaveChangesAsync();

        return existingSex;
    }

    public async Task<ISex?> DeleteSexAsync(int id)
    {
        var entity = await context.Sexes.Where(s => s.SexId == id).FirstOrDefaultAsync();

        if (entity == null)
        {
            return null;
        }

        context.Sexes.Remove(entity);
        await context.SaveChangesAsync();
        return entity;
    }
}
