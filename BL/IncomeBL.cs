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
    public class IncomeBL : IIncomeBL
    {
        private IIncomeDAL _incomeDAL;
        private ICategoryIncomeDAL _categoryIncomeDAL;
        private ISourceOfIncomeDAL _sourceOfIncomeDAL;
        private ILookupDAL _lookupDAL;

        IMapper mapper;

        public IncomeBL(IIncomeDAL incomeDAL, ICategoryIncomeDAL categoryIncomeDAL, ISourceOfIncomeDAL sourceOfIncomeDAL, ILookupDAL lookupDAL)
        {
            _incomeDAL = incomeDAL;
            _categoryIncomeDAL = categoryIncomeDAL;
            _sourceOfIncomeDAL = sourceOfIncomeDAL;
            _lookupDAL = lookupDAL;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            mapper = config.CreateMapper();
        }

        public List<IncomeDTO> GetAllIncomes()
        {
            List<Income> incomeList = _incomeDAL.GetAllIncomes();
            List<IncomeDTO> listIncomeDTO = mapper.Map<List<Income>, List<IncomeDTO>>(incomeList);

            List<CategoryIncome> categoriesIncome = _categoryIncomeDAL.GetAllCategoryIncome();
            listIncomeDTO.ForEach(item => item.CategoryIncomeDetail = categoriesIncome.FirstOrDefault(e => e.Id == item.CategoryIncome).Detail);

            List<SourceOfIncome> sourcesOfIncome = _sourceOfIncomeDAL.GetAllSourceOfIncomes();
            listIncomeDTO.ForEach(item => item.SourceOfIncomeDetail = sourcesOfIncome.FirstOrDefault(e => e.Id == item.SourceOfIncome).Detail);

            List<PaymentMethod> paymentMethods = _lookupDAL.GetAllPaymentMethod();
            listIncomeDTO.ForEach(item => item.PaymentMethodDetail = paymentMethods.FirstOrDefault(e => e.Id == item.PaymentMethod).Detail);

            List<Status> statuses = _lookupDAL.GetAllStatus();
            listIncomeDTO.ForEach(item => item.StatusDetail = statuses.FirstOrDefault(e => e.Id == item.Status).Detail);

            return listIncomeDTO;
        }

        public List<IncomeDTO> GetIncomesByBudget(int idBudget)
        {
            List<Income> incomeList = _incomeDAL.GetIncomesByBudget(idBudget);
            List<IncomeDTO> listIncomeDTO = mapper.Map<List<Income>, List<IncomeDTO>>(incomeList);

            List<CategoryIncome> categoriesIncome = _categoryIncomeDAL.GetAllCategoryIncome();
            listIncomeDTO.ForEach(item => item.CategoryIncomeDetail = categoriesIncome.FirstOrDefault(e => e.Id == item.CategoryIncome).Detail);

            List<SourceOfIncome> sourcesOfIncome = _sourceOfIncomeDAL.GetAllSourceOfIncomes();
            listIncomeDTO.ForEach(item => item.SourceOfIncomeDetail = sourcesOfIncome.FirstOrDefault(e => e.Id == item.SourceOfIncome).Detail);

            List<PaymentMethod> paymentMethods = _lookupDAL.GetAllPaymentMethod();
            listIncomeDTO.ForEach(item => item.PaymentMethodDetail = paymentMethods.FirstOrDefault(e => e.Id == item.PaymentMethod).Detail);

            List<Status> statuses = _lookupDAL.GetAllStatus();
            listIncomeDTO.ForEach(item => item.StatusDetail = statuses.FirstOrDefault(e => e.Id == item.Status).Detail);

            return listIncomeDTO;
        }

        public List<IncomeDTO> GetIncomesByBudgetGroup(int idBudget)
        {
            List<Income> incomeList = _incomeDAL.GetIncomesByBudgetGroup(idBudget);
            List<IncomeDTO> listIncomeDTO = mapper.Map<List<Income>, List<IncomeDTO>>(incomeList);

            List<CategoryIncome> categoriesIncome = _categoryIncomeDAL.GetAllCategoryIncome();
            listIncomeDTO.ForEach(item => item.CategoryIncomeDetail = categoriesIncome.FirstOrDefault(e => e.Id == item.CategoryIncome).Detail);

            List<SourceOfIncome> sourcesOfIncome = _sourceOfIncomeDAL.GetAllSourceOfIncomes();
            listIncomeDTO.ForEach(item => item.SourceOfIncomeDetail = sourcesOfIncome.FirstOrDefault(e => e.Id == item.SourceOfIncome).Detail);

            List<PaymentMethod> paymentMethods = _lookupDAL.GetAllPaymentMethod();
            listIncomeDTO.ForEach(item => item.PaymentMethodDetail = paymentMethods.FirstOrDefault(e => e.Id == item.PaymentMethod).Detail);

            List<Status> statuses = _lookupDAL.GetAllStatus();
            listIncomeDTO.ForEach(item => item.StatusDetail = statuses.FirstOrDefault(e => e.Id == item.Status).Detail);
            return listIncomeDTO;
        }


        public List<IncomeDTO> GetIncomesByDate(DateTime start, DateTime end)
        {
            List<Income> incomeList = _incomeDAL.GetIncomesByDate( start,  end);
            List<IncomeDTO> listIncomeDTO = mapper.Map<List<Income>, List<IncomeDTO>>(incomeList);
            return listIncomeDTO;
        }
    

        public List<IncomeDTO> GetIncomesBySum(double min, double max)
        {
            List<Income> incomeList = _incomeDAL.GetIncomesBySum(min, max);
            List<IncomeDTO> listIncomeDTO = mapper.Map<List<Income>, List<IncomeDTO>>(incomeList);
            return listIncomeDTO;
        }

        public List<IncomeDTO> GetIncomesByCategory(int category)
        {
            List<Income> incomeList = _incomeDAL.GetIncomesByCategory(category);
            List<IncomeDTO> listIncomeDTO = mapper.Map<List<Income>, List<IncomeDTO>>(incomeList);
            return listIncomeDTO;
        }

        public List<IncomeDTO> GetIncomesBySourceOfIncome(int sourceOfIncome)
        {
            List<Income> incomeList = _incomeDAL.GetIncomesBySourceOfIncome(sourceOfIncome);
            List<IncomeDTO> listIncomeDTO = mapper.Map<List<Income>, List<IncomeDTO>>(incomeList);
            return listIncomeDTO;
        }

        public List<IncomeDTO> GetIncomesByStatus(int status)
        {
            List<Income> incomeList = _incomeDAL.GetIncomesByStatus(status);
            List<IncomeDTO> listIncomeDTO = mapper.Map<List<Income>, List<IncomeDTO>>(incomeList);
            return listIncomeDTO;
        }

        //שליפת הכנסות באמצעות אובייקט
        public List<IncomeDTO> SearchIncomesObject(SearchDTO searchDTO)
        {
            List<Income> incomesList = _incomeDAL.SearchIncomesObject(searchDTO);
            List<IncomeDTO> listIncomeDTO = mapper.Map<List<Income>, List<IncomeDTO>>(incomesList);
            List<CategoryIncome> categories = _categoryIncomeDAL.GetAllCategoryIncome();
            listIncomeDTO.ForEach(item => item.CategoryIncomeDetail = categories.FirstOrDefault(e => e.Id == item.CategoryIncome).Detail);

            List<SourceOfIncome> sourceOfIncome = _sourceOfIncomeDAL.GetAllSourceOfIncomes();
            listIncomeDTO.ForEach(item => item.SourceOfIncomeDetail = sourceOfIncome.FirstOrDefault(e => e.Id == item.SourceOfIncome).Detail);

            List<PaymentMethod> paymentMethods = _lookupDAL.GetAllPaymentMethod();
            listIncomeDTO.ForEach(item => item.PaymentMethodDetail = paymentMethods.FirstOrDefault(e => e.Id == item.PaymentMethod).Detail);

            List<Status> statuses = _lookupDAL.GetAllStatus();
            listIncomeDTO.ForEach(item => item.StatusDetail
            = statuses.FirstOrDefault(e => e.Id == item.Status).Detail);
            return listIncomeDTO;
        }


        //שליפת דוחות בסיכום קטגוריה+תת קטגוריה בטווח תאריכים

        public List<TotalSumCategoryIncomeDTO> ReportIncomes(SearchDTO searchDTO)
        {
            List<TotalSumCategoryIncome> incomesList = _incomeDAL.ReportIncomes(searchDTO);
            List<TotalSumCategoryIncomeDTO> incomesListDTO = mapper.Map<List<TotalSumCategoryIncome>, List<TotalSumCategoryIncomeDTO>>(incomesList);

            List<CategoryIncome> categories = _categoryIncomeDAL.GetAllCategoryIncome();
            List<SourceOfIncome> sourcecategories = _sourceOfIncomeDAL.GetAllSourceOfIncomes();
            incomesListDTO.ForEach(item =>
            {
                item.CategoryDetail = categories.FirstOrDefault(c => c.Id == item.IdCategory).Detail;
                item.listSourceCategoryIncome.ForEach(sc => sc.SourceCategoryDetail = sourcecategories
                .FirstOrDefault(e => e.Id == sc.IdSourceCategory).Detail);
            });

            return incomesListDTO;
        }




        public bool AddIncome(IncomeDTO incomeDTO)
        {
            Income currentIncome = mapper.Map<IncomeDTO, Income>(incomeDTO);
            bool isSucsess = _incomeDAL.AddIncome(currentIncome);
            return isSucsess;
        }

        public bool UpdateIncome(IncomeDTO incomeDTO)
        {
            Income currentIncome = mapper.Map<IncomeDTO, Income>(incomeDTO);
            bool isSucsess = _incomeDAL.UpdateIncome(currentIncome.Id, currentIncome);
            return isSucsess;
        }

        public bool DeleteIncome(IncomeDTO incomeDTO)
        {
            int idToDelete = incomeDTO.Id;
            bool isSucsess = _incomeDAL.DeleteIncome(idToDelete);
            return isSucsess;
        }
      
    }
}
