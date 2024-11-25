﻿namespace LabA.Abstraction.IModel;

public interface IDay
{
    public int DayId { get; set; }

    public string DayName { get; set; }

    public ICollection<ISchedule> Schedules { get; set; }
}