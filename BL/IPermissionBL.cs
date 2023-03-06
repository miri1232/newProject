using DTO.Models;
using System.Collections.Generic;

namespace BL
{
    public interface IPermissionBL
    {
        List<PermissionDTO> GetAllPermission();
        List<PermissionDTO> GetAllPermissionForBudget(int idBudget);
        bool AddPermission(PermissionDTO permissionDTO);
        bool UpdatePermission(PermissionDTO permissionDTO);
        bool DeletePermission(PermissionDTO permissionDTO);
    }
}