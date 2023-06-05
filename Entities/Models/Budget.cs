using System;
using System.Collections.Generic;

#nullable disable

namespace Entities.Models
{
    public partial class Budget
    {
        public Budget()
        {
            BankOfBudgets = new HashSet<BankOfBudget>();
            Incomes = new HashSet<Income>();
            Permissions = new HashSet<Permission>();
        }

        public int Id { get; set; }
        public string NameBudget { get; set; }
        public int Type { get; set; }
        public string Manager { get; set; }

        public virtual TypeBudget TypeNavigation { get; set; }
        public virtual ICollection<BankOfBudget> BankOfBudgets { get; set; }
        public virtual ICollection<Income> Incomes { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
