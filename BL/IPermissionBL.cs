using DTO.Models;
using System.Collections.Generic;

namespace BL
{
    public interface IPermissionBL
    {
        List<PermissionDTO> GetAllPermission();
        bool AddPermission(PermissionDTO permissionDTO);
        bool UpdatePermission(PermissionDTO permissionDTO);
        bool DeletePermission(PermissionDTO permissionDTO);
    }
}