using LabA.Abstraction.IModel;
using LabA.Abstraction.IRepository;
using LabA.DAL.Data;
using LabA.DAL.Mappers;
using LabA.DAL.Mappers.Entity;
using Microsoft.EntityFrameworkCore;

namespace LabA.DAL.Repository;

public class CityRepository(LabAContext context) : ICityRepository
{
    public async Task<IEnumerable<ICity>> GetAllCitiesAsync()
    {
        var cities = await context.Cities.ToListAsync();
        return cities.Cast<ICity>().ToList();
    }

    public async Task<ICity?> GetCityByIdAsync(int id)
    {
        return await context.Cities.Where(c => c.CityId == id).FirstOrDefaultAsync();
    }

    public async Task<ICity> AddCityAsync(ICity city)
    {
        ArgumentNullException.ThrowIfNull(city, nameof(city));

        var entity = city.MapToEntity();

        await context.Cities.AddAsync(entity);
        await context.SaveChangesAsync();

        return entity;
    }

    public async Task<ICity?> UpdateCityAsync(int id, ICity city)
    {
        ArgumentNullException.ThrowIfNull(city, nameof(city));

        var entity = city.MapToEntity();
        var existingCity = await context.Cities.FirstOrDefaultAsync(c => c.CityId == id);

        if (existingCity == null)
        {
            return null;
        }

        context.Entry(existingCity).CurrentValues.SetValues(entity);
        await context.SaveChangesAsync();

        return existingCity;
    }

    public async Task<ICity?> DeleteCityAsync(int id)
    {
        var city = await context.Cities.Where(c => c.CityId == id).FirstOrDefaultAsync();

        if (city == null)
        {
            return null;
        }

        context.Cities.Remove(city);
        await context.SaveChangesAsync();
        return city;
    }
}