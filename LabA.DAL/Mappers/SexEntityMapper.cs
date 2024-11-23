using LabA.Abstraction.IModel;
using LabA.DAL.Models;

namespace LabA.DAL.Mappers;

public static class SexEntityMapper
{
    public static Sex MapToEntity(this ISex sex)
    {
        return new Sex()
        {
            SexId = sex.SexId,
            SexName = sex.SexName
        };
    }
}