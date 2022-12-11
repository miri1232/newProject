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
    public class IncomeBL : IIncomeBL
    {
        private IIncomeDAL _incomeDAL;
        IMapper mapper;

        public IncomeBL(IIncomeDAL incomeDAL)
        {
            _incomeDAL = incomeDAL;
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
            return listIncomeDTO;
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
