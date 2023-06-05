using AutoMapper;
using DAL;
using Entities.Models;
using DTO;
using DTO.Models;
using System.Collections.Generic;

namespace BL
{
    public class PermissionBL : IPermissionBL
    {
        private IPermissionDAL _permissionDAL;
        IMapper mapper;

        public PermissionBL(IPermissionDAL permissionDAL)
        {
            _permissionDAL = permissionDAL;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            mapper = config.CreateMapper();
        }
        public List<PermissionDTO> GetAllPermission()
        {
            List<Permission> permissionList = _permissionDAL.GetAllPermission();
            List<PermissionDTO> listpermissionDTO = mapper.Map<List<Permission>, List<PermissionDTO>>(permissionList);
            return listpermissionDTO;
        }

        public List<PermissionDTO> GetAllPermissionForBudget(int idBudget)
        {
            List<Permission> idUsersPermissionList = _permissionDAL.GetAllPermissionForBudget(idBudget);
            List<PermissionDTO> idUsersPermissionListDTO = mapper.Map<List<Permission>, List<PermissionDTO>>(idUsersPermissionList);
            return idUsersPermissionListDTO;
        }

        public bool AddPermission(PermissionDTO permissionDTO)
        {
            Permission currentPermission = mapper.Map<PermissionDTO, Permission>(permissionDTO);
            bool isSucsess = _permissionDAL.AddPermission(currentPermission);
            return isSucsess;
        }

        public bool UpdatePermission(PermissionDTO permissionDTO)
        {
            Permission currentPermission = mapper.Map<PermissionDTO, Permission>(permissionDTO);
            bool isSucsess = _permissionDAL.UpdatePermission(currentPermission.Id, currentPermission);
            return isSucsess;
        }

        public bool DeletePermission(PermissionDTO permissionDTO)
        {
            int idToDelete = permissionDTO.Id;
            bool isSucsess = _permissionDAL.DeletePermissions(idToDelete);
            return isSucsess;
        }
    }
}
