using LabA.Abstraction.IModel;
using LabA.Abstraction.IRepository;
using LabA.DAL.Data;
using LabA.DAL.Mappers;
using LabA.DAL.Mappers.Entity;
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

    public async Task<ISex?> GetSexByIdAsync(int id)
    {
        return await context.Sexes.Where(s => s.SexId == id).FirstOrDefaultAsync();
    }
}
