namespace ProductService.Models.Entities
{
    public abstract class BaseEntity : BaseEntity<long>
    {
    }

    public class BaseEntity<T>
    {
        public T Id { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public long? CreatorId { get; set; } = 0;
        public DateTime? ModificationDate { get; set; }
        public long? ModificationUserId { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
