namespace Pronia.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
    }
}
