using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DTO.Models
{
    public partial class MessagesDTO
    {
        //public MessagesDTO()
        //{
        //    MessagesForUser = new HashSet<MessagesForUserDTO>();
        //}

        public int Id { get; set; }
        public string Subject { get; set; }
        public string Details { get; set; }
        public string Category { get; set; }
        public int? IdBank { get; set; }
        public DateTime? EligibilityAge { get; set; }

        //public virtual BankDTO IdBankNavigation { get; set; }
        //public virtual ICollection<MessagesForUserDTO> MessagesForUser { get; set; }
    }
}
