using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Products.Handlers
{
    public class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        public ProductRemoveCommandHandler( IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
        {
            var product = await this._productRepository.GetByIdAsync(request.Id);

            if(product == null)
                throw new ApplicationException($"Error could not be found.");
            else
               return await this._productRepository.RemoveAsync(product);
      
        }
    }
}
