using Entities.Models;
using System.Collections.Generic;

namespace DAL
{
    public  interface IPermissionDAL
    {
        List<Permission> GetAllPermission();
        public List<Permission> GetAllPermissionForBudget(int idBudget);
        bool AddPermission(Permission permission);
        bool UpdatePermission(int id, Permission permission);
        bool DeletePermissions(int id);


    }
}