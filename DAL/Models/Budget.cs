using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Budget
    {
        public Budget()
        {
            BankOfBudgets = new HashSet<BankOfBudget>();
            Expenses = new HashSet<Expense>();
            Incomes = new HashSet<Income>();
            Permissions = new HashSet<Permission>();
        }

        public int Id { get; set; }
        public string NameBudget { get; set; }
        public string Type { get; set; }
        public string Manager { get; set; }

        public virtual ICollection<BankOfBudget> BankOfBudgets { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
        public virtual ICollection<Income> Incomes { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
