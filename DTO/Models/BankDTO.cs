using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DTO.Models
{
    public partial class BankDTO
    {
        //public BankDTO()
        //{
        //    Messages = new HashSet<MessagesDTO>();
        //}

        public int Id { get; set; }
        public string NameBank { get; set; }
        public string Link { get; set; }
        public string Logo_Bank { get; set; }



        //public virtual BankOfBudgetDTO BankOfBudget { get; set; }
        //public virtual ICollection<MessagesDTO> Messages { get; set; }
    }
}
