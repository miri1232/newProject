using DTO.Models;
using System.Collections.Generic;

namespace BL
{
    public interface ICategoryBL
    {
        List<CategoryDTO> GetAllCategory();
        bool AddCategory(CategoryDTO categoryDTO);
        bool UpdateCategory(CategoryDTO categoryDTO);
        bool DeleteCategory(CategoryDTO categoryDTO);
    }
}