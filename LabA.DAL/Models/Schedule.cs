﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using LabA.Abstraction.IModel;

namespace LabA.DAL.Models;

public partial class Schedule : ISchedule
{
    public int ScheduleId { get; set; }

    public int DayId { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public TimeOnly CollectionEndTime { get; set; }

    public virtual Day Day { get; set; }

    public virtual ICollection<LaboratorySchedule> LaboratorySchedules { get; set; } = new List<LaboratorySchedule>();

    ICollection<ILaboratorySchedule> ISchedule.LaboratorySchedules
    {
        get => LaboratorySchedules.Cast<ILaboratorySchedule>().ToList();
        set => LaboratorySchedules = value.Cast<LaboratorySchedule>().ToList();
    }

    IDay ISchedule.Day
    {
        get => Day;
        set => Day = (Day)value;
    }
}