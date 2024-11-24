using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            this._productRepository = productRepository;
            this._mapper = mapper;
        }

        public async Task Add(ProductDTO productDto)
        {
            var productEntity = this._mapper.Map<Product>(productDto);
            await this._productRepository.CreateAsync(productEntity);
        }

        public async Task<ProductDTO> GetById(int id)
        {
            var productEntity = this._productRepository.GetByIdAsync(id);

            var productDto = this._mapper.Map<ProductDTO>(productEntity);

            return productDto;
        }

        public async Task<ProductDTO> GetProductCategory(int id)
        {
            var productEntity = await this._productRepository.GetProductCategoryAsync(id);

            var productDto = this._mapper.Map<ProductDTO>(productEntity);

            return productDto;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsEntity = await this._productRepository.GetProductsAsync();

            var productsDto = this._mapper.Map<IEnumerable<ProductDTO>>(productsEntity);

            return productsDto;
        }

        public async Task Remove(int id)
        {
            var productEntity = await this._productRepository.GetByIdAsync(id);

            await this._productRepository.RemoveAsync(productEntity);
        }

        public async Task Update(ProductDTO productDto)
        {
            var productEntity = this._mapper.Map<Product>(productDto);

            await this._productRepository.UpdateAsync(productEntity);
        }
    }
}
