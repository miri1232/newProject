using DAL.Models;
using System.Collections.Generic;

namespace DAL
{
    public  interface IPermissionDAL
    {
        List<Permission> GetAllPermission();
        bool AddPermission(Permission permission);
        bool UpdatePermission(int id, Permission permission);
        bool DeletePermissions(int id);


    }
}