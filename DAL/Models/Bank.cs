using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Bank
    {
        public Bank()
        {
            Messages = new HashSet<Message>();
        }

        public int Id { get; set; }
        public string NameBank { get; set; }
        public string Link { get; set; }

        public virtual BankOfBudget BankOfBudget { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
