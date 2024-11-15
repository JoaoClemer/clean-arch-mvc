﻿using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : BaseEntity
    {
        public Product(string name, string description, decimal price, int stock, string image)
        {
            this.ValidateDomain(name, description, price, stock, image);   
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            this.Id = id;
            this.ValidateDomain(name, description, price, stock, image);
        }

        public string Description { get; private set; }

        public decimal Price { get; private set; }

        public int Stock { get; private set; }

        public string Image { get; private set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            this.ValidateDomain(name, description, price, stock, image);
            this.CategoryId = categoryId;
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");

            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 characters");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid description. Description is required");

            DomainExceptionValidation.When(description.Length < 5, "Invalid description, too short, minimum 5 characters");

            DomainExceptionValidation.When(price < 0, "Invalid price value");

            DomainExceptionValidation.When(stock < 0, "Invalid stock value");

            DomainExceptionValidation.When(image?.Length > 250, "Invalid image name, too long, maximum 250 characters");

            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Stock = stock;
            this.Image = image;
        }
    }
}
