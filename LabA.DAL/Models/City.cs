﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using LabA.Abstraction.IModel;

namespace LabA.DAL.Models;

public partial class City : ICity
{
    public int CityId { get; set; }

    public string CityName { get; set; }

    public virtual ICollection<Laboratory> Laboratories { get; set; } = new List<Laboratory>();
}