using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class BankOfBudget
    {
        public int Id { get; set; }
        public int IdBudget { get; set; }
        public int IdBank { get; set; }

        public virtual Bank IdBankNavigation { get; set; }
        public virtual Budget IdBudgetNavigation { get; set; }
    }
}
