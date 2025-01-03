﻿using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnityTest
    {
        [Fact]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "product image");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 9.99m, 99, "product image");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id value");
        }

        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 9.99m, 99, "product image");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, too short, minimum 3 characters");
        }

        [Fact]
        public void CreateProduct_MissingNameValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(1, "", "Product Description", 9.99m, 99, "product image");

            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Invalid name. Name is required");
        }


        [Fact]
        public void CreateProduct_LongImageName_DomainExceptionLongImageName()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "product image toooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo looooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooong");

            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Invalid image name, too long, maximum 250 characters");
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, null);
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_InvalidStockValue_ExceptionDomainNegativeValue()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, -5, "image name");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid stock value");
        }

        [Fact]
        public void CreateProduct_InvalidPriceValue_ExceptionDomainNegativeValue()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", -9.99m, 99, "image name");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid price value");
        }

    }
}
