﻿namespace LabA.Abstraction.IModel;

public interface ILaboratory
{
    public int LaboratoryId { get; set; }

    public string Address { get; set; }

    public int CityId { get; set; }

    public string PhoneNumber { get; set; }

    public ICity City { get; set; }

    public ICollection<IEmployee> Employees { get; set; }

    public ICollection<ILaboratorySchedule> LaboratorySchedules { get; set; }
}