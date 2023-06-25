using AutoMapper;
using DAL;
using Entities.Models;
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

        public List<ExpenseDTO> GetExpensesByBudget(int budget)
        {
            List<Expense> expenseList = _expenseDAL.GetExpensesByBudget(budget);
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

        public List<ExpenseDTO> GetExpensesByDate(int budget)
        {
            List<Expense> expenseList = _expenseDAL.GetExpensesByDate(budget);
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
            List<Expense> expenseList = _expenseDAL.SearchExpenses(start, end, min, max, category, Subcategory, paymentMethod, status);
            List<ExpenseDTO> listExpenseDTO = mapper.Map<List<Expense>, List<ExpenseDTO>>(expenseList);
            return listExpenseDTO;
        }
        //שליפת הוצאות באמצעות אובייקט
        public List<ExpenseDTO> SearchExpensesObject(SearchDTO searchDTO)
        {
            List<Expense> expenseList = _expenseDAL.SearchExpensesObject(searchDTO);
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

        public ExpenseDTO AddExpense(ExpenseDTO expenseDTO)
        {
            Expense currentExpense = mapper.Map<ExpenseDTO, Expense>(expenseDTO);
          
            List<Category> categories = _categoryDAL.GetAllCategory();
            expenseDTO.CategoryDetail = categories.FirstOrDefault(e => e.Id == currentExpense.Category).Detail;

            List<Subcategory> subcategories = _subcategoryDAL.GetAllSubcategory();
            expenseDTO.SubcategoryDetail = subcategories.FirstOrDefault(e => e.Id == currentExpense.Subcategory).Detail;

            List<PaymentMethod> paymentMethods = _lookupDAL.GetAllPaymentMethod();
            expenseDTO.PaymentMethodDetail = paymentMethods.FirstOrDefault(e => e.Id == currentExpense.PaymentMethod).Detail;

            List<Status> statuses = _lookupDAL.GetAllStatus();
            expenseDTO.StatusDetail = statuses.FirstOrDefault(e => e.Id == currentExpense.Status).Detail;

            int expId = _expenseDAL.AddExpense(currentExpense);
            expenseDTO.Id = expId;
            return expenseDTO;
        }

        public ExpenseDTO UpdateExpense(ExpenseDTO expenseDTO)
        {
        

            Expense currentExpense = mapper.Map<ExpenseDTO, Expense>(expenseDTO);
            List<Category> categories = _categoryDAL.GetAllCategory();
            expenseDTO.CategoryDetail = categories.FirstOrDefault(e => e.Id == currentExpense.Category).Detail;

            List<Subcategory> subcategories = _subcategoryDAL.GetAllSubcategory();
            expenseDTO.SubcategoryDetail = subcategories.FirstOrDefault(e => e.Id == currentExpense.Subcategory).Detail;

            List<PaymentMethod> paymentMethods = _lookupDAL.GetAllPaymentMethod();
            expenseDTO.PaymentMethodDetail = paymentMethods.FirstOrDefault(e => e.Id == currentExpense.PaymentMethod).Detail;

            List<Status> statuses = _lookupDAL.GetAllStatus();
            expenseDTO.StatusDetail = statuses.FirstOrDefault(e => e.Id == currentExpense.Status).Detail;

            Expense exp = _expenseDAL.UpdateExpense(currentExpense.Id, currentExpense);
            return expenseDTO;
        }

        public bool DeleteExpense(ExpenseDTO expenseDTO)
        {
            int idToDelete = expenseDTO.Id;
            bool isSucsess = _expenseDAL.DeleteExpense(idToDelete);
            return isSucsess;
        }

        //public List<ObjectSumSubCategoryDTO> ReportSubCategoryExpenses(int idBudget)
        //{
        //    List<ObjectSumSubCategory> expenseList = _expenseDAL.ReportSubCategoryExpenses(idBudget);
        //    List<ObjectSumSubCategoryDTO> listExpenseDTO = mapper.Map<List<ObjectSumSubCategory>, List<ObjectSumSubCategoryDTO>>(expenseList);

        //    //List<Subcategory> subcategories = _subcategoryDAL.GetAllSubcategory();
        //    //listExpenseDTO.ForEach(item => item.SubcategoryDetail = subcategories.FirstOrDefault(e => e.Id == item.IdSubcategory).Detail);


        //    return listExpenseDTO;
        //}

        //public List<ObjectSumCategoryDTO> ReportCategoryExpenses(int idBudget)
        //{
        //    List<ObjectSumCategory> expenseList = _expenseDAL.ReportCategoryExpenses(idBudget);
        //    List<ObjectSumCategoryDTO> listExpenseDTO = mapper.Map<List<ObjectSumCategory>, List<ObjectSumCategoryDTO>>(expenseList);


        //    List<Category> categories = _categoryDAL.GetAllCategory();
        //    listExpenseDTO.ForEach(item => item.CategoryDetail = categories.FirstOrDefault(e => e.Id == item.IdCategory).Detail);

        //    return listExpenseDTO;
        //}

        public List<TotalSumCategoryDTO> ReportExpenses2(int idBudget)
        {
            List<TotalSumCategory> expenseList = _expenseDAL.ReportExpenses2(idBudget);
            List<TotalSumCategoryDTO> listExpenseDTO = mapper.Map<List<TotalSumCategory>, List<TotalSumCategoryDTO>>(expenseList);
            //List<TotalSumSubCategoryDTO> listSubCategoryDTO = mapper.Map<List<TotalSumSubCategory>, List<TotalSumSubCategoryDTO>>(expenseList.listSubCategory);

            List<Category> categories = _categoryDAL.GetAllCategory();
            List<Subcategory> subcategories = _subcategoryDAL.GetAllSubcategory();
            listExpenseDTO.ForEach(item =>
            {
                item.CategoryDetail = categories.FirstOrDefault(e => e.Id == item.IdCategory).Detail;
                item.listSubCategory
    .ForEach(sc => sc.SubcategoryDetail = subcategories.FirstOrDefault(e => e.Id == sc.IdSubcategory).Detail);

            });


            return listExpenseDTO;
        }

        //שליפת דוחות בסיכום קטגוריה+תת קטגוריה בטווח תאריכים

       public List<TotalSumCategoryDTO> ReportExpenses3(SearchDTO searchDTO)
        {
            List<TotalSumCategory> expenseList = _expenseDAL.ReportExpenses3(searchDTO);
            List<TotalSumCategoryDTO> listExpenseDTO = mapper.Map<List<TotalSumCategory>, List<TotalSumCategoryDTO>>(expenseList);

            List<Category> categories = _categoryDAL.GetAllCategory();
            List<Subcategory> subcategories = _subcategoryDAL.GetAllSubcategory();

            listExpenseDTO.ForEach(item =>
            {
                item.CategoryDetail = categories.FirstOrDefault(e => e.Id == item.IdCategory).Detail;
                item.listSubCategory.ForEach(sc => sc.SubcategoryDetail = subcategories.FirstOrDefault(e => e.Id == sc.IdSubcategory).Detail);

            });



            return listExpenseDTO;
        }

    }


}
