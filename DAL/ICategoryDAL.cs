using DAL.Models;
using System.Collections.Generic;

namespace DAL
{
    public interface ICategoryDAL
    {
        List<Category> GetAllCategory();
        bool AddCategory(Category category);
        bool UpdateCategory(int id, Category category);
        bool DeleteCategory(int id);
       
    }
}