namespace LabA.Abstraction.IRepository;

public interface IUnitOfWork
{

    public IAnalysisRepository AnalysisRepository { get; }
    public IAnalysisCategoryRepository AnalysisCategoryRepository { get; }
    public IAnalysisBiomaterailRepository AnalysisBiomaterailRepository { get; }
    public IAnalysisResultRepository AnalysisResultRepository { get; }
    public IBiomaterailRepository BiomaterailRepository { get; }
    public IClientRepository ClientRepository { get; }
    public ICityRepository CityRepository { get; }
    public IDayRepository DayRepository { get; }
    public IEmployeeRepository EmployeeRepository { get; }
    public ILaboratoryRepository LaboratoryRepository { get; }
    public ILaboratoryScheduleRepository LaboratoryScheduleRepository { get; }
    public IOrderRepository OrderRepository { get; }
    public IOrderAnalysisRepository OrderAnalysisRepository { get; }
    public IPositionRepository PositionRepository { get; }
    public IScheduleRepository ScheduleRepository { get; }
    public ISexRepository SexRepository { get; }
    public IStatusRepository StatusRepository { get; }

    public Task SaveChanges();
}