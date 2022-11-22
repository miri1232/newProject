using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DTO.Models
{
    public partial class Budget
    {
        public Budget()
        {
            BankOfBudget = new HashSet<BankOfBudget>();
            Expenses = new HashSet<Expenses>();
            Incomes = new HashSet<Incomes>();
        }

        public int Id { get; set; }
        public string NameBudget { get; set; }
        public string Type { get; set; }
        public string Permissions { get; set; }
        public string Manager { get; set; }

        public virtual ICollection<BankOfBudget> BankOfBudget { get; set; }
        public virtual ICollection<Expenses> Expenses { get; set; }
        public virtual ICollection<Incomes> Incomes { get; set; }
    }
}
