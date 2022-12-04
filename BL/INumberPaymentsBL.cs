using DTO.Models;
using System.Collections.Generic;

namespace BL
{
    public interface INumberPaymentsBL
    {
        List<NumberPaymentsDTO> GetAllNumberPayments();
        bool AddNumberPayments(NumberPaymentsDTO numberPaymentsDTO);
        bool UpdateNumberPayments(NumberPaymentsDTO numberPaymentsDTO);
        bool DeleteNumberPayments(NumberPaymentsDTO numberPaymentsDTO);
    }
}