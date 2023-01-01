using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Permission
    {
        public int Id { get; set; }
        public string IdUser { get; set; }
        public int IdBudget { get; set; }
        public int PermissionLevel { get; set; }

        public virtual Budget IdBudgetNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
        public virtual PermissionLevel PermissionLevelNavigation { get; set; }
    }
}
