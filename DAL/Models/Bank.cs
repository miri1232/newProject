using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL.Models
{
    public partial class Bank
    {
        public Bank()
        {
            Messages = new HashSet<Messages>();
        }

        public int Id { get; set; }
        public string NameBank { get; set; }
        public string Link { get; set; }

        public virtual BankOfBudget BankOfBudget { get; set; }
        public virtual ICollection<Messages> Messages { get; set; }
    }
}
