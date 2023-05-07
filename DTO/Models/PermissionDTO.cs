using System;
using System.Collections.Generic;


namespace DTO.Models
{
    public partial class PermissionDTO
    {
        public int Id { get; set; }
        public string IdUser { get; set; }
        public int IdBudget { get; set; }
        public int PermissionLevel { get; set; }
    
    }
}
