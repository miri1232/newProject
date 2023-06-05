using Entities.Models;
using System.Collections.Generic;

namespace DAL
{
    public interface ICategoryIncomeDAL
    {
        List<CategoryIncome> GetAllCategoryIncome();
        CategoryIncome GetCategoryIncomeByID(int idCategoryIncome);
        bool AddCategoryIncome(CategoryIncome categoryIncome);
        bool UpdateCategoryIncome(int id, CategoryIncome categoryIncome);
        bool DeleteCategoryIncome(int id);
    }
}