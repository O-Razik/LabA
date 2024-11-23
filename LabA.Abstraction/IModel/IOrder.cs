namespace LabA.Abstraction.IModel;

public interface IOrder
{
    public int OrderId { get; set; }

    public int? Number { get; set; }

    public int StatusId { get; set; }

    public int EmployeeId { get; set; }

    public int ClientId { get; set; }

    public DateTime BiomaterialCollectionDate { get; set; }

    public double Fullprice { get; set; }
}