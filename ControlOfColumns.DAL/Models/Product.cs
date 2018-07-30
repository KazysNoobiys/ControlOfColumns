namespace ControlOfColumns.DAL.Models
{
    public class Product
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual double Price { get; set; }
        public virtual string Description { get; set; }
        public virtual int Quantity { get; set; }
        public virtual string Commnets { get; set; }
    }
}