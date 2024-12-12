using LabA.Abstraction.IModel;
using LabA.DAL.Models;

namespace LabA.DAL.Mappers.Entity;

public static class BiomateralEntityMapper
{
    public static Biomaterial MapToEntity(this IBiomaterial biomaterial)
    {
        return new Biomaterial
        {
            BiomaterialId = biomaterial.BiomaterialId,
            BiomaterialName = biomaterial.BiomaterialName
        };
    }
}