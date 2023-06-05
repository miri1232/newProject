using System;
using System.Collections.Generic;

#nullable disable

namespace Entities.Models
{
    public partial class PermissionLevel
    {
        public PermissionLevel()
        {
            Permissions = new HashSet<Permission>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
