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
    public class ExpenseBL : IExpenseBL
    {
        private IExpenseDAL _expenseDAL;
        private ICategoryDAL _categoryDAL;
        private ISubcategoryDAL _subcategoryDAL;
        private ILookupDAL _lookupDAL;

        IMapper mapper;

        public ExpenseBL(IExpenseDAL expenseDAL, ICategoryDAL categoryDAL, ISubcategoryDAL subcategoryDAL, ILookupDAL lookupDAL)
        {
            _expenseDAL = expenseDAL;
            _categoryDAL = categoryDAL;
            _subcategoryDAL = subcategoryDAL;
            _lookupDAL = lookupDAL;

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
            
            List<Category> categories = _categoryDAL.GetAllCategory();
            listExpenseDTO.ForEach(item => item.CategoryDetail = categories.FirstOrDefault(e => e.Id == item.Category).Detail);
           
            List<Subcategory> subcategories = _subcategoryDAL.GetAllSubcategory();
            listExpenseDTO.ForEach(item => item.SubcategoryDetail = subcategories.FirstOrDefault(e => e.Id == item.Subcategory).Detail);
            
            List<PaymentMethod> paymentMethods = _lookupDAL.GetAllPaymentMethod();
            listExpenseDTO.ForEach(item => item.PaymentMethodDetail = paymentMethods.FirstOrDefault(e => e.Id == item.PaymentMethod).Detail);
            
            List<Status> statuses = _lookupDAL.GetAllStatus();
            listExpenseDTO.ForEach(item => item.StatusDetail 
            = statuses.FirstOrDefault(e => e.Id == item.Status).Detail);


            return listExpenseDTO;
        }
        public List<ExpenseDTO> GetExpensesByDate(DateTime start, DateTime end)
        {
            List<Expense> expenseList = _expenseDAL.GetExpensesByDate(start, end);
            List<ExpenseDTO> listExpenseDTO = mapper.Map<List<Expense>, List<ExpenseDTO>>(expenseList);
            return listExpenseDTO;
        }
        public List<ExpenseDTO> GetExpensesBySum(double min, double max)
        {
            List<Expense> expenseList = _expenseDAL.GetExpensesBySum(min, max);
            List<ExpenseDTO> listExpenseDTO = mapper.Map<List<Expense>, List<ExpenseDTO>>(expenseList);
            return listExpenseDTO;
        }
        public List<ExpenseDTO> GetExpensesByCategory(int category)
        {
            List<Expense> expenseList = _expenseDAL.GetExpensesByCategory(category);
            List<ExpenseDTO> listExpenseDTO = mapper.Map<List<Expense>, List<ExpenseDTO>>(expenseList);
            return listExpenseDTO;
        }

        public List<ExpenseDTO> GetExpensesBySubcategory(int subcategory)
        {
            List<Expense> expenseList = _expenseDAL.GetExpensesBySubcategory(subcategory);
            List<ExpenseDTO> listExpenseDTO = mapper.Map<List<Expense>, List<ExpenseDTO>>(expenseList);
            return listExpenseDTO;
        }
        public List<ExpenseDTO> GetExpensesByPaymentMethod(int paymentMethod)
        {
            List<Expense> expenseList = _expenseDAL.GetExpensesByPaymentMethod(paymentMethod);
            List<ExpenseDTO> listExpenseDTO = mapper.Map<List<Expense>, List<ExpenseDTO>>(expenseList);
            return listExpenseDTO;
        }
        public List<ExpenseDTO> GetExpensesByStatus(int status)
        {
            List<Expense> expenseList = _expenseDAL.GetExpensesByStatus(status);
            List<ExpenseDTO> listExpenseDTO = mapper.Map<List<Expense>, List<ExpenseDTO>>(expenseList);
            return listExpenseDTO;
        }
 public List<ExpenseDTO> SearchExpenses(DateTime start, DateTime end, double min, double max, int category, int Subcategory, int paymentMethod, int status)
        {
            List<Expense> expenseList = _expenseDAL.SearchExpenses( start,  end,  min,  max,  category,  Subcategory,  paymentMethod,  status);
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
