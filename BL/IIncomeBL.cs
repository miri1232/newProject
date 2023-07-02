using DTO.Models;
using System;
using System.Collections.Generic;

namespace BL
{
    public interface IIncomeBL
    {
        List<IncomeDTO> GetAllIncomes();
        List<IncomeDTO> GetIncomesByBudget(int idBudget);
        bool AddIncome(IncomeDTO incomeDTO);
        bool UpdateIncome(IncomeDTO incomeDTO);
        bool DeleteIncome(IncomeDTO incomeDTO);
        List<IncomeDTO> GetIncomesByDate(DateTime start, DateTime end);
        List<IncomeDTO> GetIncomesBySum(double min, double max);
        List<IncomeDTO> GetIncomesByCategory(int category);
        List<IncomeDTO> GetIncomesBySourceOfIncome(int sourceOfIncome);
        List<IncomeDTO> GetIncomesByStatus(int status);
        List<IncomeDTO> GetIncomesByBudgetGroup(int idBudget);
        List<IncomeDTO> SearchIncomesObject(SearchDTO searchDTO);
        List<TotalSumCategoryIncomeDTO> ReportIncomes(SearchDTO searchDTO);

    }
}