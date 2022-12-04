using AutoMapper;
using DAL;
using DAL.Models;
using DTO;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ExpensesBL : IExpensesBL
    {
        private IExpensesDAL _expensesDAL;
        IMapper mapper;

        public ExpensesBL(IExpensesDAL expensesDAL)
        {
            _expensesDAL = expensesDAL;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            mapper = config.CreateMapper();
        }

        public List<ExpensesDTO> GetAllExpenses()
        {
            List<Expenses> expensesList = _expensesDAL.GetAllExpenses();
            List<ExpensesDTO> listExpensesDTO = mapper.Map<List<Expenses>, List<ExpensesDTO>>(expensesList);
            return listExpensesDTO;
        }


        public bool AddExpenses(ExpensesDTO expensesDTO)
        {
            Expenses currentExpenses = mapper.Map<ExpensesDTO, Expenses>(expensesDTO);
            bool isSucsess = _expensesDAL.AddExpense(currentExpenses);
            return isSucsess;
        }

        public bool UpdateExpenses(ExpensesDTO expensesDTO)
        {
            Expenses currentExpenses = mapper.Map<ExpensesDTO, Expenses>(expensesDTO);
            bool isSucsess = _expensesDAL.UpdateExpenses(currentExpenses.Id, currentExpenses);
            return isSucsess;
        }

        public bool DeleteExpenses(ExpensesDTO expensesDTO)
        {
            int idToDelete = expensesDTO.Id;
            bool isSucsess = _expensesDAL.DeleteExpenses(idToDelete);
            return isSucsess;
        }

      
    }

    
}
