using DTO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public interface ICategoryIncomeBL
    {
        List<CategoryIncomeDTO> GetAllCategoryIncome();
        CategoryIncomeDTO GetCategoryIncomeByID(int idCategoryIncome);
        bool AddCategoryIncome(CategoryIncomeDTO categoryIncomeDTO);
        bool UpdateCategoryIncome(CategoryIncomeDTO categoryIncomeDTO);
        bool DeleteCategoryIncome(CategoryIncomeDTO categoryIncomeDTO);


    }
}
