using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DTO.Models
{
    public partial class Permission
    {
        public string IdUser { get; set; }
        public int IdBudget { get; set; }
        public int PermissionLevel { get; set; }

        public virtual Users IdUserNavigation { get; set; }
        public virtual PermissionLevel PermissionLevelNavigation { get; set; }
    }
}
