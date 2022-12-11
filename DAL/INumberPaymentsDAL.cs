using DAL.Models;
using System.Collections.Generic;

namespace DAL
{
    public interface INumberPaymentsDAL
    {
        List<NumberPayments> GetAllNumberPayments();
        bool AddNumberPayments(NumberPayments numberPayments);
        bool UpdateNumberPayments(int id, NumberPayments numberPayments);
        bool DeleteNumberPayments(int id);

    }
}