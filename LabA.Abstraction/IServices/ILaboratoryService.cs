﻿using LabA.Abstraction.IModel;

namespace LabA.Abstraction.IServices;

public interface ILaboratoryService
{
    public Task<IEnumerable<ILaboratory>> GetAllLaboratoriesAsync();
    public Task<ILaboratory?> GetLaboratoryByIdAsync(int id);
    public Task<ILaboratory> AddLaboratoryAsync(ILaboratory laboratory);
    public Task<ILaboratory?> UpdateLaboratoryAsync(int id, ILaboratory laboratory);
    public Task<ILaboratory?> DeleteLaboratoryAsync(int id);
}