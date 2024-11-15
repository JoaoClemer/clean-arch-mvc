using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : BaseEntity
    {
        public Category(string name)
        {
            this.ValidateDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            this.Id = id;
            this.ValidateDomain(name);
        }

        public ICollection<Product> Products { get; set; }

        public void Update( string name)
        {
            this.ValidateDomain(name);
        }

        private void ValidateDomain( string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");

            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 characters");

            this.Name = name;
        }
    }
}
