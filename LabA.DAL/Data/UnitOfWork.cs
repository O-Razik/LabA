using LabA.Abstraction.IRepository;
using LabA.DAL.Repository;

namespace LabA.DAL.Data;

public class UnitOfWork(LabAContext context) : IUnitOfWork
{
    private readonly LabAContext context = context;

    public IAnalysisRepository AnalysisRepository { get; } = new AnalysisRepository(context);
    public IAnalysisCategoryRepository AnalysisCategoryRepository { get; } = new AnalysisCategoryRepository(context);
    public IAnalysisBiomaterailRepository AnalysisBiomaterailRepository { get; } = new AnalysisBiomaterailRepository(context);
    public IAnalysisResultRepository AnalysisResultRepository { get; } = new AnalysisResultRepository(context);
    public IBiomaterailRepository BiomaterailRepository { get; } = new BiomaterailRepository(context);
    public IClientRepository ClientRepository { get; } = new ClientRepository(context);
    public ICityRepository CityRepository { get; } = new CityRepository(context);
    public IDayRepository DayRepository { get; } = new DayRepository(context);
    public IEmployeeRepository EmployeeRepository { get; } = new EmployeeRepository(context);
    public ILaboratoryRepository LaboratoryRepository { get; } = new LaboratoryRepository(context);
    public ILaboratoryScheduleRepository LaboratoryScheduleRepository { get; } = new LaboratoryScheduleRepository(context);
    public IOrderRepository OrderRepository { get; } = new OrderRepository(context);
    public IOrderAnalysisRepository OrderAnalysisRepository { get; } = new OrderAnalysisRepository(context);
    public IPositionRepository PositionRepository { get; } = new PositionRepository(context);
    public IScheduleRepository ScheduleRepository { get; } = new ScheduleRepository(context);
    public ISexRepository SexRepository { get; } = new SexRepository(context);
    public IStatusRepository StatusRepository { get; } = new StatusRepository(context);

    public Task SaveChanges()
    {
        return this.context.SaveChangesAsync();
    }
}
