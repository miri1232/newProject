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
    public class NumberPaymentsBL : INumberPaymentsBL
    {
        private INumberPaymentsDAL _numberPaymentsDAL;
        IMapper mapper;

        public NumberPaymentsBL(INumberPaymentsDAL numberPaymentsDAL)
        {
            _numberPaymentsDAL = numberPaymentsDAL;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            mapper = config.CreateMapper();
        }

        public List<NumberPaymentsDTO> GetAllNumberPayments()
        {
            List<NumberPayments> numberPaymentsList = _numberPaymentsDAL.GetAllNumberPayments();
            List<NumberPaymentsDTO> listNumberPaymentsDTO = mapper.Map<List<NumberPayments>, List<NumberPaymentsDTO>>(numberPaymentsList);
            return listNumberPaymentsDTO;
        }


        public bool AddNumberPayments(NumberPaymentsDTO numberPaymentsDTO)
        {
            NumberPayments currentNumberPayments = mapper.Map<NumberPaymentsDTO, NumberPayments>(numberPaymentsDTO);
            bool isSucsess = _numberPaymentsDAL.AddNumberPayments(currentNumberPayments);
            return isSucsess;
        }

        public bool UpdateNumberPayments(NumberPaymentsDTO numberPaymentsDTO)
        {
            NumberPayments currentNumberPayments = mapper.Map<NumberPaymentsDTO, NumberPayments>(numberPaymentsDTO);
            bool isSucsess = _numberPaymentsDAL.UpdateNumberPayments(currentNumberPayments.Id, currentNumberPayments);
            return isSucsess;
        }

        public bool DeleteNumberPayments(NumberPaymentsDTO numberPaymentsDTO)
        {
            int idToDelete = numberPaymentsDTO.Id;
            bool isSucsess = _numberPaymentsDAL.DeleteNumberPayments(idToDelete);
            return isSucsess;
        }
        
    }
}
