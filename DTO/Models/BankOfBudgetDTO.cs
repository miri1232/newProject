using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DTO.Models
{
    public partial class BankOfBudgetDTO
    {
        public int IdBank { get; set; }
        public int IdBudget { get; set; }

        //public virtual BankDTO IdBankNavigation { get; set; }
        //public virtual BudgetDTO IdBudgetNavigation { get; set; }
    }
}
