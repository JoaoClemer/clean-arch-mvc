namespace CleanArchMvc.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; protected set; }

        public string Name { get; protected set; }

    }
}
