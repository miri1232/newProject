using DAL.Models;
using System.Collections.Generic;

namespace DAL
{
    public interface INumberPaymentsDAL
    {
        List<NumberPayments> GetAllNumberPayments();
        bool AddNumberPayments(NumberPayments nmberPayments);
        bool UpdateNumberPayments(int id, NumberPayments nmberPayments);
        bool DeleteNumberPayments(int id);

    }
}