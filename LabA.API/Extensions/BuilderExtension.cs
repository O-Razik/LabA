using Microsoft.EntityFrameworkCore;
using AutoMapper;


using LabA.Abstraction.IServices;
using LabA.BLL.Services;
using LabA.DAL.Data;
using LabA.Abstraction.IModel;
using LabA.Abstraction.IRepository;
using LabA.DAL.Models;
using LabA.DAL.Repository;

namespace LabA.API.Extensions;

public static class BuilderExtension
{
    public static void AddAll(this WebApplicationBuilder builder)
    {
        builder.AddDbContext();
        builder.AddModels();
        builder.AddRepositories();
        builder.AddServices();
        //builder.Services.AddAutoMapper(typeof(BLL.AutoMapper.AutoMapper).Assembly);
    }

    public static void AddDbContext(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<LabAContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
    }

    public static void AddModels(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAnalysis, Analysis>();
        builder.Services.AddScoped<IAnalysisCategory, AnalysisCategory>();
        builder.Services.AddScoped<IAnalysisResult, AnalysisResult>();
        builder.Services.AddScoped<IAnalysisBiomaterial, AnalysisBiomaterial>();
        builder.Services.AddScoped<IBiomaterial, Biomaterial>();
        builder.Services.AddScoped<ICity, City>();
        builder.Services.AddScoped<IClient, Client>();
        builder.Services.AddScoped<IDay, Day>();
        builder.Services.AddScoped<IEmployee, Employee>();
        builder.Services.AddScoped<ILaboratory, Laboratory>();
        builder.Services.AddScoped<ILaboratorySchedule, LaboratorySchedule>();
        builder.Services.AddScoped<IPosition, Position>();
        builder.Services.AddScoped<ISchedule, Schedule>();
        builder.Services.AddScoped<ISex, Sex>();
    }

    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAnalysisService, AnalysisService>();
        builder.Services.AddScoped<IAnalysisCategoryService, AnalysisCategoryService>();
        builder.Services.AddScoped<IAnalysisResultService, AnalysisResultService>();
        builder.Services.AddScoped<IAnalysisBiomaterialService, AnalysisBiomaterailService>();
        builder.Services.AddScoped<IBiomaterialService, BiomaterialService>();
        builder.Services.AddScoped<ICityService, CityService>();
        builder.Services.AddScoped<IClientService, ClientService>();
        builder.Services.AddScoped<IDayService, DayService>();
        builder.Services.AddScoped<IEmployeeService, EmployeeService>();
        builder.Services.AddScoped<ILaboratoryService, LaboratoryService>();
        builder.Services.AddScoped<ILaboratoryScheduleService, LaboratoryScheduleService>();
        builder.Services.AddScoped<IPositionService, PositionService>();
        builder.Services.AddScoped<IScheduleService, ScheduleService>();
        builder.Services.AddScoped<ISexService, SexService>();
        builder.Services.AddScoped<IOrderService, OrderService>();
        builder.Services.AddScoped<IOrderAnalysisService, OrderAnalysisService>();
        builder.Services.AddScoped<IStatusService, StatusService>();
    }

    public static void AddRepositories(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<IAnalysisRepository, AnalysisRepository>();
        builder.Services.AddScoped<IAnalysisCategoryRepository, AnalysisCategoryRepository>();
        builder.Services.AddScoped<IAnalysisResultRepository, AnalysisResultRepository>();
        builder.Services.AddScoped<IAnalysisBiomaterialRepository, AnalysisBiomaterialRepository>();
        builder.Services.AddScoped<IBiomaterialRepository, BiomaterialRepository>();
        builder.Services.AddScoped<ICityRepository, CityRepository>();
        builder.Services.AddScoped<IClientRepository, ClientRepository>();
        builder.Services.AddScoped<IDayRepository, DayRepository>();
        builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        builder.Services.AddScoped<ILaboratoryRepository, LaboratoryRepository>();
        builder.Services.AddScoped<ILaboratoryScheduleRepository, LaboratoryScheduleRepository>();
        builder.Services.AddScoped<IPositionRepository, PositionRepository>();
        builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();
        builder.Services.AddScoped<IStatusService, StatusService>();
        builder.Services.AddScoped<ISexRepository, SexRepository>();
        builder.Services.AddScoped<IOrderRepository, OrderRepository>();
        builder.Services.AddScoped<IOrderAnalysisRepository, OrderAnalysisRepository>();
    }
}