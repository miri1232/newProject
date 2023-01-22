using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class NumberPayment
    {
        public int Id { get; set; }
        public int IdExpenses { get; set; }
        public DateTime Date { get; set; }
        public double Sum { get; set; }
        public string Status { get; set; }
        public string Detail { get; set; }

        public virtual Expense IdExpensesNavigation { get; set; }
    }
}
