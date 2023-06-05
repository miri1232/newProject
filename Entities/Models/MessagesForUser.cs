using System;
using System.Collections.Generic;

#nullable disable

namespace Entities.Models
{
    public partial class MessagesForUser
    {
        public int Id { get; set; }
        public string IdUser { get; set; }
        public int IdMessages { get; set; }
        public bool Status { get; set; }

        public virtual Message IdMessagesNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
