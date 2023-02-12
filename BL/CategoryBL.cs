using AutoMapper;
using DAL;
using DAL.Models;
using DTO;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CategoryBL  : ICategoryBL
    {
        private ICategoryDAL _categoryDAL;
        IMapper mapper;

        public CategoryBL(ICategoryDAL categoryDAL)
        {
            _categoryDAL = categoryDAL;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            mapper = config.CreateMapper();
        }

        public List<CategoryDTO> GetAllCategory()
        {
            List<Category> categoryList = _categoryDAL.GetAllCategory();
            List<CategoryDTO> listCategoryDTO = mapper.Map<List<Category>, List<CategoryDTO>>(categoryList);
            return listCategoryDTO;
        }

        public CategoryDTO GetCategoryByID(int idCategory)
        {
            Category category = _categoryDAL.GetCategoryByID(idCategory);
            CategoryDTO categoryDTO = mapper.Map<Category,CategoryDTO>(category);
            return categoryDTO;
        }


        public bool AddCategory(CategoryDTO categoryDTO)
        {
            Category currentCategory = mapper.Map<CategoryDTO, Category>(categoryDTO);
            bool isSucsess = _categoryDAL.AddCategory(currentCategory);
            return isSucsess;
        }

        public bool UpdateCategory(CategoryDTO categoryDTO)
        {
            Category currentCategory = mapper.Map<CategoryDTO, Category>(categoryDTO);
            bool isSucsess = _categoryDAL.UpdateCategory(currentCategory.Id, currentCategory);
            return isSucsess;
        }

        public bool DeleteCategory(CategoryDTO categoryDTO)
        {
            int idToDelete = categoryDTO.Id;
            bool isSucsess = _categoryDAL.DeleteCategory(idToDelete);
            return isSucsess;
        }

       
    }
}
