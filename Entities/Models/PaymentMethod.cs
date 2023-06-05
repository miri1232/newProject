using System;
using System.Collections.Generic;

#nullable disable

namespace Entities.Models
{
    public partial class PaymentMethod
    {
        public PaymentMethod()
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
