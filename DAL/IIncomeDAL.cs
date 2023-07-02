using DTO.Models;
using Entities.Models;
using System;
using System.Collections.Generic;

namespace DAL
{
    public interface IIncomeDAL
    {
        List<Income> GetAllIncomes();
        List<Income> GetIncomesByBudget(int idBudget);
        bool AddIncome(Income income);
        bool UpdateIncome(int id, Income income);
        bool DeleteIncome(int id);
        List<Income> GetIncomesByDate(DateTime start, DateTime end);
        List<Income> GetIncomesBySum(double min, double max);
        List<Income> GetIncomesByCategory(int category);
        List<Income> GetIncomesBySourceOfIncome(int sourceOfIncome);
        List<Income> GetIncomesByStatus(int status);
        List<Income> GetIncomesByBudgetGroup(int idBudget);
        List<Income> SearchIncomesObject(SearchDTO searchDTO);
        List<TotalSumCategoryIncome> ReportIncomes(SearchDTO searchDTO);

    }
}