using System;
using System.Collections.Generic;


namespace DTO.Models
{
    public partial class PermissionDTO
    {
        public int Id { get; set; }
        public string IdUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IdBudget { get; set; }
        public int PermissionLevel { get; set; }
        public string PermissionLevelDetail { get; set; } 
    }
}
