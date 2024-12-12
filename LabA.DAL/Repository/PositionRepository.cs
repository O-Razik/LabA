using LabA.Abstraction.IModel;
using LabA.Abstraction.IRepository;
using LabA.DAL.Data;
using LabA.DAL.Mappers;
using LabA.DAL.Mappers.Entity;
using Microsoft.EntityFrameworkCore;

namespace LabA.DAL.Repository;

public class PositionRepository(LabAContext context) : IPositionRepository
{
    public async Task<IEnumerable<IPosition>> GetAllPositionsAsync()
    {
        var positions = await context.Positions.ToListAsync();
        return positions.Cast<IPosition>().ToList();
    }

    public async Task<IPosition?> GetPositionByIdAsync(int id)
    {
        return await context.Positions.FirstOrDefaultAsync(p => p.PositionId == id);
    }

    public async Task<IPosition> AddPositionAsync(IPosition position)
    {
        ArgumentNullException.ThrowIfNull(position, nameof(position));

        var entity = position.MapToEntity();
        await context.Positions.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<IPosition?> UpdatePositionAsync(int id, IPosition position)
    {
        ArgumentNullException.ThrowIfNull(position, nameof(position));

        var existingPosition = await context.Positions.FirstOrDefaultAsync(p => p.PositionId == id);
        if (existingPosition == null)
        {
            return null;
        }

        context.Entry(existingPosition).CurrentValues.SetValues(position);
        await context.SaveChangesAsync();

        return position;
    }

    public async Task<IPosition?> DeletePositionAsync(int id)
    {
        var position = await context.Positions.Where(p => p.PositionId == id).FirstOrDefaultAsync();

        if (position == null)
        {
            return null;
        }

        context.Positions.Remove(position);
        await context.SaveChangesAsync();

        return position;
    }

}