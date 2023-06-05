using Entities.Models;
using System.Collections.Generic;

namespace DAL
{
    public interface ISourceOfIncomeDAL
    {
         List<SourceOfIncome> GetAllSourceOfIncomes();
         List<SourceOfIncome> GetSourceOfIncomeByID(int idSourceOfIncome);
         bool AddSourceOfIncome(SourceOfIncome SourceOfIncome);
         bool UpdateSourceOfIncome(int id, SourceOfIncome sourceOfIncome);
         bool DeleteSourceOfIncome(int id);
       
    }
}