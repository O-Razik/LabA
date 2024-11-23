﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using LabA.Abstraction.IModel;

namespace LabA.DAL.Models;

public partial class Employee : IEmployee
{
    public int EmployeeId { get; set; }

    public int PositionId { get; set; }

    public int LaboratoryId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }

    public virtual Laboratory Laboratory { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Position Position { get; set; }
}