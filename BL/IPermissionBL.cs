using DTO.Models;
using System.Collections.Generic;

namespace BL
{
    public interface IPermissionBL
    {
        List<PermissionDTO> GetAllPermission();
        List<PermissionDTO> GetAllPermissionForBudget(int idBudget);
        int GetLevelPermissionForBudgetByID(int idBudget, string id);

        bool AddPermission(PermissionDTO permissionDTO);
        bool UpdatePermission(PermissionDTO permissionDTO);
        bool DeletePermission(PermissionDTO permissionDTO);
    }
}