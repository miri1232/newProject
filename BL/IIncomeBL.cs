using DTO.Models;
using System;
using System.Collections.Generic;

namespace BL
{
    public interface IIncomeBL
    {
        List<IncomeDTO> GetAllIncomes();
        bool AddIncome(IncomeDTO incomeDTO);
        bool UpdateIncome(IncomeDTO incomeDTO);
        bool DeleteIncome(IncomeDTO incomeDTO);
        List<IncomeDTO> GetIncomesByDate(DateTime start, DateTime end);
    }
}