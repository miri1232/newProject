using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Status
    {
        public Status()
        {
            Expenses = new HashSet<Expense>();
            Incomes = new HashSet<Income>();
        }

        public int Id { get; set; }
        public string Detail { get; set; }

        public virtual ICollection<Expense> Expenses { get; set; }
        public virtual ICollection<Income> Incomes { get; set; }
    }
}
