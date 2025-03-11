namespace Locadora.Core.DomainObjects
{
    public class Entity
    {
        public Guid Id { get; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdateAt { get; protected set; }
        public DateTime? DeleteAt { get; protected set; }
        
        public Entity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
        }

    }
}
