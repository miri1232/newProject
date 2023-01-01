﻿using AutoMapper;
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
    public class ExpenseBL : IExpenseBL
    {
        private IExpenseDAL _expenseDAL;
        IMapper mapper;

        public ExpenseBL(IExpenseDAL expenseDAL)
        {
            _expenseDAL = expenseDAL;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            mapper = config.CreateMapper();
        }

        public List<ExpenseDTO> GetAllExpenses()
        {
            List<Expense> expenseList = _expenseDAL.GetAllExpenses();
            List<ExpenseDTO> listExpenseDTO = mapper.Map<List<Expense>, List<ExpenseDTO>>(expenseList);
            return listExpenseDTO;
        }
        public List<ExpenseDTO> GetExpensesByDate(DateTime start, DateTime end)
        {
            List<Expense> expenseList = _expenseDAL.GetExpensesByDate(start, end);
            List<ExpenseDTO> listExpenseDTO = mapper.Map<List<Expense>, List<ExpenseDTO>>(expenseList);
            return listExpenseDTO;
        }
        public List<Expense> GetExpensesBySum(double start, double end)
        {
            List<Expense> expenseList = _expenseDAL.GetExpensesBySum(start, end);
            List<ExpenseDTO> listExpenseDTO = mapper.Map<List<Expense>, List<ExpenseDTO>>(expenseList);
            return listExpenseDTO;
        }
        public List<Expense> GetExpensesByCategory(string category)
        {
            List<Expense> expenseList = _expenseDAL.GetExpensesByCategory(category);
            List<ExpenseDTO> listExpenseDTO = mapper.Map<List<Expense>, List<ExpenseDTO>>(expenseList);
            return listExpenseDTO;
        }
        public List<ExpenseDTO> GetExpensesByPaymentMethod(string paymentMethod)
        {
            List<Expense> expenseList = _expenseDAL.GetExpensesByPaymentMethod(paymentMethod);
            List<ExpenseDTO> listExpenseDTO = mapper.Map<List<Expense>, List<ExpenseDTO>>(expenseList);
            return listExpenseDTO;
        }
        public List<ExpenseDTO> GetExpensesByStatus(string status)
        {
            List<Expense> expenseList = _expenseDAL.GetExpensesByStatus(status);
            List<ExpenseDTO> listExpenseDTO = mapper.Map<List<Expense>, List<ExpenseDTO>>(expenseList);
            return listExpenseDTO;
        }


        public bool AddExpense(ExpenseDTO expenseDTO)
        {
            Expense currentExpense = mapper.Map<ExpenseDTO, Expense>(expenseDTO);
            bool isSucsess = _expenseDAL.AddExpense(currentExpense);
            return isSucsess;
        }

        public bool UpdateExpense(ExpenseDTO expenseDTO)
        {
            Expense currentExpense = mapper.Map<ExpenseDTO, Expense>(expenseDTO);
            bool isSucsess = _expenseDAL.UpdateExpense(currentExpense.Id, currentExpense);
            return isSucsess;
        }

        public bool DeleteExpense(ExpenseDTO expenseDTO)
        {
            int idToDelete = expenseDTO.Id;
            bool isSucsess = _expenseDAL.DeleteExpense(idToDelete);
            return isSucsess;
        }

      
    }

    
}
