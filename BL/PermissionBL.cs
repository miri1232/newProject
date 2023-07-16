using AutoMapper;
using DAL;
using Entities.Models;
using DTO;
using DTO.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class PermissionBL : IPermissionBL
    {
        private IPermissionDAL _permissionDAL;
        private ILookupDAL _lookupDAL;
        private IUserDAL _userDAL;
        IMapper mapper;

        public PermissionBL(IPermissionDAL permissionDAL,IUserDAL userDAL, ILookupDAL lookupDAL)
        {
            _permissionDAL = permissionDAL;
            _lookupDAL = lookupDAL;
            _userDAL = userDAL;

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


            List<PermissionLevel> permissionLevels = _lookupDAL.GetAllPermissionLevel();
            idUsersPermissionListDTO.ForEach(item => item.PermissionLevelDetail = permissionLevels.FirstOrDefault(e => e.Id == item.PermissionLevel).Description);

            List<User> users = _userDAL.GetAllUsers();
            idUsersPermissionListDTO.ForEach(item => item.FirstName = users.FirstOrDefault(e => e.Id == item.IdUser).FirstName);
            idUsersPermissionListDTO.ForEach(item => item.LastName = users.FirstOrDefault(e => e.Id == item.IdUser).LastName);

            return idUsersPermissionListDTO;
        }
       public int GetLevelPermissionForBudgetByID(int idBudget, string id)
{
            int PermissionLevelForUser = _permissionDAL.GetLevelPermissionForBudgetByID(idBudget,id);
           
            return PermissionLevelForUser;
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
