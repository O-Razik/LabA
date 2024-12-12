namespace LabA.Abstraction.DTO;

public class OrderDto
{
    public int OrderId { get; set; }

    public int? Number { get; set; }

    public StatusDto Status { get; set; }

    public EmployeeDto Employee { get; set; }

    public ClientDto Client { get; set; }

    public DateTime BiomaterialCollectionDate { get; set; }

    public ICollection<OrderAnalysisDto> OrderAnalyses { get; set; }

    public double Fullprice { get; set; }
}