using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL.Models
{
    public partial class NumberPayments
    {
        public int Id { get; set; }
        public int IdExpenses { get; set; }
        public DateTime Date { get; set; }
        public double Sum { get; set; }
        public string Status { get; set; }
        public string Detail { get; set; }

        public virtual Expenses IdExpensesNavigation { get; set; }
    }
}
