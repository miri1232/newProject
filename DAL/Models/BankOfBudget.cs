using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL.Models
{
    public partial class BankOfBudget
    {
        public int IdBank { get; set; }
        public int IdBudget { get; set; }

        public virtual Bank IdBankNavigation { get; set; }
        public virtual Budget IdBudgetNavigation { get; set; }
    }
}
