using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using MediatR;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {

        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductService(IMediator mediator, IMapper mapper)
        {
            this._mediator = mediator;
            this._mapper = mapper;
        }

        public async Task Add(ProductDTO productDto)
        {
            var productCreateCommand = this._mapper.Map<ProductCreateCommand>(productDto);

            await this._mediator.Send(productCreateCommand);

        }

        public async Task<ProductDTO> GetById(int id)
        {
            var productByIdQuery = new GetProductByIdQuery(id);

            var resut = this._mediator.Send(productByIdQuery);

            var productDto = this._mapper.Map<ProductDTO>(resut);

            return productDto;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsQuery = new GetProductsQuery();

            var result = await this._mediator.Send(productsQuery);

            var productsDto = this._mapper.Map<IEnumerable<ProductDTO>>(result);

            return productsDto;
        }

        public async Task Remove(int id)
        {
            var productRemoveCommand = new ProductRemoveCommand(id);

            await this._mediator.Send(productRemoveCommand);

        }

        public async Task Update(ProductDTO productDto)
        {
            var productUpdateCommand = this._mapper.Map<ProductUpdateCommand>(productDto);

            await this._mediator.Send(productUpdateCommand);
        }
    }
}
