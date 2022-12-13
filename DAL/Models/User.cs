using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class User
    {
        public User()
        {
            MessagesForUsers = new HashSet<MessagesForUser>();
            Permissions = new HashSet<Permission>();
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateBirth { get; set; }

        public virtual ICollection<MessagesForUser> MessagesForUsers { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
