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
   public class BankOfBudgetBL : IBankOfBudgetBL
    {

        private IBankOfBudgetDAL _bankOfBudgetDAL;
        IMapper mapper;

        public BankOfBudgetBL(IBankOfBudgetDAL bankOfBudgetDAL)
        {
            _bankOfBudgetDAL = bankOfBudgetDAL;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            mapper = config.CreateMapper();
        }


      
        public List<BankOfBudgetDTO> GetAllBankOfBudgets()
        {
        List<BankOfBudget> bankOfBudgetList = _bankOfBudgetDAL.GetAllBankOfBudgets();
        List<BankOfBudgetDTO> ListBankOfBudgetDTO = mapper.Map<List<BankOfBudget>, List<BankOfBudgetDTO>>(bankOfBudgetList);
            return ListBankOfBudgetDTO;
        }

        public BankOfBudgetDTO GetBankOfBudgetByID(int idBankOfBudget)
        {
            BankOfBudget bankOfBudget = _bankOfBudgetDAL.GetBankOfBudgetByID( idBankOfBudget);
        BankOfBudgetDTO bankOfBudgetDTO = mapper.Map<BankOfBudget, BankOfBudgetDTO>(bankOfBudget);
            return bankOfBudgetDTO;
        }


        public List<BankOfBudgetDTO> GetBankOfBudgetByIdBudget(int idBudget)
        {
            List<BankOfBudget> bankOfBudgetList = _bankOfBudgetDAL.GetBankOfBudgetByIdBudget(idBudget);
            List<BankOfBudgetDTO> listBankOfBudgetDTO = mapper.Map<List<BankOfBudget>, List<BankOfBudgetDTO>>(bankOfBudgetList);
            return listBankOfBudgetDTO;
        }

        public bool AddBankOfBudget(BankOfBudgetDTO bankOfBudgetDTO)
               {
            BankOfBudget currentBankOfBudget = mapper.Map<BankOfBudgetDTO, BankOfBudget>(bankOfBudgetDTO);
            bool isSucsess = _bankOfBudgetDAL.AddBankOfBudget(currentBankOfBudget);
            return isSucsess;
        }

        public bool UpdateBankOfBudget(BankOfBudgetDTO bankOfBudgetDTO)
        {
            BankOfBudget currentBankOfBudget = mapper.Map<BankOfBudgetDTO, BankOfBudget>(bankOfBudgetDTO);
            bool isSucsess = _bankOfBudgetDAL.UpdateBankOfBudget(currentBankOfBudget.Id, currentBankOfBudget);
            return isSucsess;
        }

        public bool DeleteBankOfBudget(BankOfBudgetDTO bankOfBudgetDTO)
        {
            int idToDelete = bankOfBudgetDTO.Id;
            bool isSucsess = _bankOfBudgetDAL.DeleteBankOfBudget(idToDelete);
            return isSucsess;
        }



    }
}
