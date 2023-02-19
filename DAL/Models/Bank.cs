using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Bank
    {
        public Bank()
        {
            BankOfBudgets = new HashSet<BankOfBudget>();
            Messages = new HashSet<Message>();
        }

        public int Id { get; set; }
        public string NameBank { get; set; }
        public string Link { get; set; }
        public string Logo_Bank { get; set; }


        public virtual ICollection<BankOfBudget> BankOfBudgets { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
