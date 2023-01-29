using DAL.Models;
using System.Collections.Generic;

namespace DAL
{
    public interface ISourceOfIncomeDAL
    {
         List<SourceOfIncome> GetAllSourceOfIncomes();
         SourceOfIncome GetSourceOfIncomeByID(int idSourceOfIncome);
        List<SourceOfIncome> GetSourceOfIncomeByUser(string idUser);
         bool AddSourceOfIncome(SourceOfIncome SourceOfIncome);
         bool UpdateSourceOfIncome(int id, SourceOfIncome sourceOfIncome);
         bool DeleteSourceOfIncome(int id);
       
    }
}