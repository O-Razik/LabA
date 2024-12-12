using LabA.Abstraction.IModel;
using LabA.DAL.Models;

namespace LabA.DAL.Mappers.Entity;

public static class LaboratoryEntityMapper
{
    public static Laboratory MapToEntity(this ILaboratory laboratory)
    {
        return new Laboratory
        {
            LaboratoryId = laboratory.LaboratoryId,
            CityId = laboratory.CityId,
            City = laboratory.City.MapToEntity(),
            Address = laboratory.Address,
            PhoneNumber = laboratory.PhoneNumber,
            LaboratorySchedules = laboratory.LaboratorySchedules.Select(ls => ls.MapToEntity()).ToList(),
        };
    }
}