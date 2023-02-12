using DAL.Models;
using System.Collections.Generic;

namespace DAL
{
    public interface ICategoryDAL
    {
        List<Category> GetAllCategory();
        Category GetCategoryByID (int idCategory);
        bool AddCategory(Category category);
        bool UpdateCategory(int id, Category category);
        bool DeleteCategory(int id);
       
    }
}