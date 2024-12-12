using LabA.Abstraction.DTO;
using LabA.Abstraction.IModel;

namespace LabA.Abstraction.IRepository;

public interface ILaboratoryRepository
{
    public Task<IEnumerable<ILaboratory>> GetAllLaboratoriesAsync();
    public Task<ILaboratory?> GetLaboratoryByIdAsync(int id);
    public Task<ILaboratory> AddLaboratoryAsync(ILaboratory laboratory);
    public Task<ILaboratory?> UpdateLaboratoryAsync(int id, ILaboratory laboratory);
    public Task<ILaboratory?> DeleteLaboratoryAsync(int id);
    Task<IEnumerable<ILaboratory>> GetLaboratoriesByCityAsync(int id);
}