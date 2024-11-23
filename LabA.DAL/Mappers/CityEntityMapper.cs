using LabA.Abstraction.IModel;
using LabA.DAL.Models;

namespace LabA.DAL.Mappers;

public static class CityEntityMapper
{
    public static City MapToEntity(this ICity city)
    {
        return new City
        {
            CityId = city.CityId,
            CityName = city.CityName
        };
    }
}