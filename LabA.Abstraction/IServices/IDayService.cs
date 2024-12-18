﻿using LabA.Abstraction.IModel;

namespace LabA.Abstraction.IServices;

public interface IDayService
{
    public Task<IEnumerable<IDay>> GetAllDaysAsync();
    public Task<IDay?> GetDayByIdAsync(int id);

    public void Validate(IDay day);
}