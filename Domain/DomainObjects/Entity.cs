namespace SeventhServers.Domain.DomainObjects
{
    public class Entity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }


        public void Delete()
        {
            DeletedAt = DateTime.Now;
        }
    }
}
