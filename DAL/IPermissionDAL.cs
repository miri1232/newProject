using Entities.Models;
using System.Collections.Generic;

namespace DAL
{
    public  interface IPermissionDAL
    {
        List<Permission> GetAllPermission();
         List<Permission> GetAllPermissionForBudget(int idBudget);
         int GetLevelPermissionForBudgetByID(int idBudget, string id);

        bool AddPermission(Permission permission);
        bool UpdatePermission(int id, Permission permission);
        bool DeletePermissions(int id);


    }
}