using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this._categoryRepository = categoryRepository;
            this._mapper = mapper;
        }

        public async Task Add(CategoryDTO categoryDto)
        {
           var categoryEntity = this._mapper.Map<Category>(categoryDto);
           await this._categoryRepository.CreateAsync(categoryEntity);
        }

        public async Task<CategoryDTO> GetById(int id)
        {
            var categoryEntity = this._categoryRepository.GetByIdAsync(id);

            var categoryDto = this._mapper.Map<CategoryDTO>(categoryEntity);

            return categoryDto;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categoriesEntity = await this._categoryRepository.GetCategoriesAsync();

            var categoriesDto = this._mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);

            return categoriesDto;
        }

        public async Task Remove(int id)
        {
            var categoryEntity = await this._categoryRepository.GetByIdAsync(id);

            await this._categoryRepository.RemoveAsync(categoryEntity);
        }

        public async Task Update(CategoryDTO categoryDto)
        {
            var categoryEntity = this._mapper.Map<Category>(categoryDto);

            await this._categoryRepository.UpdateAsync(categoryEntity);
        }
    }
}
