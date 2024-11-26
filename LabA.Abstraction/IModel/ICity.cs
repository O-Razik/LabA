namespace LabA.Abstraction.IModel;

public interface ICity
{
    public int CityId { get; set; }

    public string CityName { get; set; }

    public ICollection<ILaboratory> Laboratories { get; set; }
}