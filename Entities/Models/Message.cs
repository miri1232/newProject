using System;
using System.Collections.Generic;

#nullable disable

namespace Entities.Models
{
    public partial class Message
    {
        public Message()
        {
            MessagesForUsers = new HashSet<MessagesForUser>();
        }

        public int Id { get; set; }
        public string Subject { get; set; }
        public string Details { get; set; }
        public string Category { get; set; }
        public int? IdBank { get; set; }
        public DateTime? EligibilityAge { get; set; }

        public virtual Bank IdBankNavigation { get; set; }
        public virtual ICollection<MessagesForUser> MessagesForUsers { get; set; }
    }
}
