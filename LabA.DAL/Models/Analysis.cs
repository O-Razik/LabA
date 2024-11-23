﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using LabA.Abstraction.IModel;

namespace LabA.DAL.Models;

public partial class Analysis : IAnalysis
{
    public int AnalysisId { get; set; }

    public string Name { get; set; }

    public int CategoryId { get; set; }

    public string Description { get; set; }

    public double? Price { get; set; }

    public virtual ICollection<AnalysisBiomaterial> AnalysisBiomaterials { get; set; } = new List<AnalysisBiomaterial>();

    public virtual AnalysisCategory Category { get; set; }

    public virtual ICollection<OrderAnalysis> OrderAnalyses { get; set; } = new List<OrderAnalysis>();
}