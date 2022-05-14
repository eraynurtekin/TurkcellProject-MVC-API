using AutoMapper;
using FastShop.DataAccess.Data;
using FastShop.DataAccess.Repositories;
using FastShop.Dtos.Responses;
using FastShop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastShop.Business
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private IMapper mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public async Task<IList<CategoryListResponse>> GetAllCategory()
        {
            var categories = await categoryRepository.GetAllEntites();

            var categoriesListResponse = mapper.Map<IList<CategoryListResponse>>(categories);
            return categoriesListResponse;
        }

        public IList<CategoryListResponse> GetCategories()
        {
            var categories = categoryRepository.GetAll();
            
            var categoriesListResponse = mapper.Map<List<CategoryListResponse>>(categories);
            return categoriesListResponse;
        }
    }
}
