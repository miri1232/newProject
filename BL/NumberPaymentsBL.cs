﻿using AutoMapper;
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
            List<NumberPayment> numberPaymentsList = _numberPaymentsDAL.GetAllNumberPayments();
            List<NumberPaymentsDTO> listNumberPaymentsDTO = mapper.Map<List<NumberPayment>, List<NumberPaymentsDTO>>(numberPaymentsList);
            return listNumberPaymentsDTO;
        }


        public bool AddNumberPayments(NumberPaymentsDTO numberPaymentsDTO)
        {
            NumberPayment currentNumberPayments = mapper.Map<NumberPaymentsDTO, NumberPayment>(numberPaymentsDTO);
            bool isSucsess = _numberPaymentsDAL.AddNumberPayments(currentNumberPayments);
            return isSucsess;
        }

        public bool UpdateNumberPayments(NumberPaymentsDTO numberPaymentsDTO)
        {
            NumberPayment currentNumberPayments = mapper.Map<NumberPaymentsDTO, NumberPayment>(numberPaymentsDTO);
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
