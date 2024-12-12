using System.Linq;
using LabA.Abstraction.IModel;
using LabA.DAL.Models;
using AutoMapper;


namespace LabA.BLL.AutoMapper;

public class AutoMapper : Profile
{
    public AutoMapper()
    {
        CreateMap<Day, IDay>()
            .ForMember(dest => dest.Schedules, opt => opt.MapFrom(src => src.Schedules.Cast<ISchedule>().ToList()));
        CreateMap<IDay, Day>()
            .ForMember(dest => dest.Schedules, opt => opt.MapFrom(src => src.Schedules.Cast<Schedule>().ToList()));

        CreateMap<Biomaterial, IBiomaterial>()
            .ForMember(dest => dest.AnalysisBiomaterials, opt => opt.MapFrom(src => src.AnalysisBiomaterials.Cast<IAnalysisBiomaterial>().ToList()));
        CreateMap<IBiomaterial, Biomaterial>()
            .ForMember(dest => dest.AnalysisBiomaterials, opt => opt.MapFrom(src => src.AnalysisBiomaterials.Cast<AnalysisBiomaterial>().ToList()));

        CreateMap<AnalysisResult, IAnalysisResult>()
            .ForMember(dest => dest.OrderAnalysis, opt => opt.MapFrom(src => src.OrderAnalysis));
        CreateMap<IAnalysisResult, AnalysisResult>()
            .ForMember(dest => dest.OrderAnalysis, opt => opt.MapFrom(src => src.OrderAnalysis));

        CreateMap<AnalysisBiomaterial, IAnalysisBiomaterial>()
            .ForMember(dest => dest.Analysis, opt => opt.MapFrom(src => src.Analysis))
            .ForMember(dest => dest.Biomaterial, opt => opt.MapFrom(src => src.Biomaterial));
        CreateMap<IAnalysisBiomaterial, AnalysisBiomaterial>()
            .ForMember(dest => dest.Analysis, opt => opt.MapFrom(src => src.Analysis))
            .ForMember(dest => dest.Biomaterial, opt => opt.MapFrom(src => src.Biomaterial));

        CreateMap<AnalysisCategory, IAnalysisCategory>()
            .ForMember(dest => dest.Analyses, opt => opt.MapFrom(src => src.Analyses.Cast<IAnalysis>().ToList()));
        CreateMap<IAnalysisCategory, AnalysisCategory>()
            .ForMember(dest => dest.Analyses, opt => opt.MapFrom(src => src.Analyses.Cast<Analysis>().ToList()));

        CreateMap<Analysis, IAnalysis>()
            .ForMember(dest => dest.AnalysisBiomaterials, opt => opt.MapFrom(src => src.AnalysisBiomaterials.Cast<IAnalysisBiomaterial>().ToList()))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
            .ForMember(dest => dest.OrderAnalyses, opt => opt.MapFrom(src => src.OrderAnalyses.Cast<IOrderAnalysis>().ToList()));
        CreateMap<IAnalysis, Analysis>()
            .ForMember(dest => dest.AnalysisBiomaterials, opt => opt.MapFrom(src => src.AnalysisBiomaterials.Cast<AnalysisBiomaterial>().ToList()))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
            .ForMember(dest => dest.OrderAnalyses, opt => opt.MapFrom(src => src.OrderAnalyses.Cast<OrderAnalysis>().ToList()));

        CreateMap<OrderAnalysis, IOrderAnalysis>()
            .ForMember(dest => dest.Analysis, opt => opt.MapFrom(src => src.Analysis))
            .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Order));
        CreateMap<IOrderAnalysis, OrderAnalysis>()
            .ForMember(dest => dest.Analysis, opt => opt.MapFrom(src => src.Analysis))
            .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Order));

        CreateMap<Order, IOrder>()
            .ForMember(dest => dest.OrderAnalyses, opt => opt.MapFrom(src => src.OrderAnalyses.Cast<IOrderAnalysis>().ToList()))
            .ForMember(dest => dest.Client, opt => opt.MapFrom(src => src.Client))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => dest.Employee, opt => opt.MapFrom(src => src.Employee));
        CreateMap<IOrder, Order>()
            .ForMember(dest => dest.OrderAnalyses, opt => opt.MapFrom(src => src.OrderAnalyses.Cast<OrderAnalysis>().ToList()))
            .ForMember(dest => dest.Client, opt => opt.MapFrom(src => src.Client))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => dest.Employee, opt => opt.MapFrom(src => src.Employee));

        CreateMap<Position, IPosition>()
            .ForMember(dest => dest.Employees, opt => opt.MapFrom(src => src.Employees.Cast<IEmployee>().ToList()));
        CreateMap<IPosition, Position>()
            .ForMember(dest => dest.Employees, opt => opt.MapFrom(src => src.Employees.Cast<Employee>().ToList()));

        CreateMap<Employee, IEmployee>()
            .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position))
            .ForMember(dest => dest.Laboratory, opt => opt.MapFrom(src => src.Laboratory))
            .ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src.Orders.Cast<IOrder>().ToList()));
        CreateMap<IEmployee, Employee>()
            .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position))
            .ForMember(dest => dest.Laboratory, opt => opt.MapFrom(src => src.Laboratory))
            .ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src.Orders.Cast<Order>().ToList()));

        CreateMap<Laboratory, ILaboratory>()
            .ForMember(dest => dest.Employees, opt => opt.MapFrom(src => src.Employees.Cast<IEmployee>().ToList()))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
            .ForMember(dest => dest.LaboratorySchedules, opt => opt.MapFrom(src => src.LaboratorySchedules.Cast<ILaboratorySchedule>().ToList()));
        CreateMap<ILaboratory, Laboratory>()
            .ForMember(dest => dest.Employees, opt => opt.MapFrom(src => src.Employees.Cast<Employee>().ToList()))
            .ForMember(dest => dest.LaboratorySchedules, opt => opt.MapFrom(src => src.LaboratorySchedules.Cast<LaboratorySchedule>().ToList()));

        CreateMap<LaboratorySchedule, ILaboratorySchedule>()
            .ForMember(dest => dest.Laboratory, opt => opt.MapFrom(src => src.Laboratory))
            .ForMember(dest => dest.Schedule, opt => opt.MapFrom(src => src.Schedule));
        CreateMap<ILaboratorySchedule, LaboratorySchedule>()
            .ForMember(dest => dest.Laboratory, opt => opt.MapFrom(src => src.Laboratory))
            .ForMember(dest => dest.Schedule, opt => opt.MapFrom(src => src.Schedule));

        CreateMap<Schedule, ISchedule>()
            .ForMember(dest => dest.LaboratorySchedules, opt => opt.MapFrom(src => src.LaboratorySchedules.Cast<ILaboratorySchedule>().ToList()))
            .ForMember(dest => dest.Day, opt => opt.MapFrom(src => src.Day));
        CreateMap<ISchedule, Schedule>()
            .ForMember(dest => dest.LaboratorySchedules, opt => opt.MapFrom(src => src.LaboratorySchedules.Cast<LaboratorySchedule>().ToList()))
            .ForMember(dest => dest.Day, opt => opt.MapFrom(src => src.Day));

        CreateMap<City, ICity>()
            .ForMember(dest => dest.Laboratories, opt => opt.MapFrom(src => src.Laboratories.Cast<ILaboratory>().ToList()));
        CreateMap<ICity, City>()
            .ForMember(dest => dest.Laboratories, opt => opt.MapFrom(src => src.Laboratories.Cast<Laboratory>().ToList()));

        CreateMap<Client, IClient>()
            .ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src.Orders.Cast<IOrder>().ToList()))
            .ForMember(dest => dest.Sex, opt => opt.MapFrom(src => src.Sex));
        CreateMap<IClient, Client>()
            .ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src.Orders.Cast<Order>().ToList()))
            .ForMember(dest => dest.Sex, opt => opt.MapFrom(src => src.Sex));

        CreateMap<Status, IStatus>()
            .ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src.Orders.Cast<IOrder>().ToList()));
        CreateMap<IStatus, Status>()
            .ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src.Orders.Cast<Order>().ToList()));

        CreateMap<Sex, ISex>()
            .ForMember(dest => dest.Clients, opt => opt.MapFrom(src => src.Clients.Cast<IClient>().ToList()));
        CreateMap<ISex,Sex>()
            .ForMember(dest => dest.Clients, opt => opt.MapFrom(src => src.Clients.Cast<Client>().ToList()));
    }
}