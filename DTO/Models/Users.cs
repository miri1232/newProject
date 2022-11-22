using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DTO.Models
{
    public partial class Users
    {
        public Users()
        {
            MessagesForUser = new HashSet<MessagesForUser>();
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateBirth { get; set; }

        public virtual Permission Permission { get; set; }
        public virtual ICollection<MessagesForUser> MessagesForUser { get; set; }
    }
}
