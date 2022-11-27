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
    public class BudgetBL : IBudgetBL
    {
        private IBudgetDAL _budgetDAL;
        IMapper mapper;

        public BudgetBL(IBudgetDAL budgetDAL)
        {
            _budgetDAL = budgetDAL;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            mapper = config.CreateMapper();
        }

        public List<BudgetDTO> GetAllBudget()
        {
            List<Budget> budgetList = _budgetDAL.GetAllBudgets();
            List<BudgetDTO> listBudgetDTO = mapper.Map<List<Budget>, List<BudgetDTO>>(budgetList);
            return listBudgetDTO;
        }


        public bool AddBudget(BudgetDTO budgetDTO)
        {
            Budget currentBudget = mapper.Map<BudgetDTO, Budget>(budgetDTO);
            bool isSucsess = _budgetDAL.AddBudget(currentBudget);
            return isSucsess;
        }

        public bool UpdateBudget(BudgetDTO budgetDTO)
        {
            Budget currentBudget = mapper.Map<BudgetDTO, Budget>(budgetDTO);
            bool isSucsess = _budgetDAL.UpdateBudget(currentBudget.Id, currentBudget);
            return isSucsess;
        }

        public bool DeleteBudget(BudgetDTO budgetDTO)
        {
            int idToDelete = budgetDTO.Id;
            bool isSucsess = _budgetDAL.DeleteBudget(idToDelete);
            return isSucsess;
        }
    }

    
}
