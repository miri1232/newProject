using Entities.Models;
using System.Collections.Generic;

namespace DAL
{
    public interface INumberPaymentsDAL
    {
        List<NumberPayment> GetAllNumberPayments();
        bool AddNumberPayments(NumberPayment numberPayments);
        bool UpdateNumberPayments(int id, NumberPayment numberPayments);
        bool DeleteNumberPayments(int id);

    }
}