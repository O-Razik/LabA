using LabA.Abstraction.IModel;
using LabA.DAL.Models;

namespace LabA.DAL.Mappers;

public static class LaboratoryEntityMapper
{
    public static Laboratory MapToEntity(this ILaboratory laboratory)
    {
        return new Laboratory
        {
            LaboratoryId = laboratory.LaboratoryId,
            CityId = laboratory.CityId,
            Address = laboratory.Address,
            PhoneNumber = laboratory.PhoneNumber
        };
    }
}