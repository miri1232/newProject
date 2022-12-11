using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class MessagesForUser
    {
        public string IdUser { get; set; }
        public int IdMessages { get; set; }
        public bool? Status { get; set; }

        public virtual Message IdMessagesNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
