using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DTO.Models
{
    public partial class BudgetDTO
    {
        //public BudgetDTO()
        //{
        //    BankOfBudget = new HashSet<BankOfBudgetDTO>();
        //    Expenses = new HashSet<ExpensesDTO>();
        //    Incomes = new HashSet<IncomesDTO>();
        //}

        public int Id { get; set; }
        public string NameBudget { get; set; }
        public string Type { get; set; }
        //public string Permissions { get; set; }
        public string Manager { get; set; }

        //public virtual ICollection<BankOfBudgetDTO> BankOfBudget { get; set; }
        //public virtual ICollection<ExpensesDTO> Expenses { get; set; }
        //public virtual ICollection<IncomesDTO> Incomes { get; set; }
    }
}
