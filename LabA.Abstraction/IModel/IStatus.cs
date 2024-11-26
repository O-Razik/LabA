namespace LabA.Abstraction.IModel
{
    public interface IStatus
    {
        public int StatusId { get; set; }

        public string StatusName { get; set; }

        public ICollection<IOrder> Orders { get; set; }
    }
}
