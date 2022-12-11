using AutoMapper;
using DAL;
using DAL.Models;
using DTO;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class UserBL : IUserBL
    {
        private IUserDAL _userDAL;
        IMapper mapper;

        public UserBL(IUserDAL userDAL)
        {
            _userDAL = userDAL;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            mapper = config.CreateMapper();
        }

        public List<UserDTO> GetAllUsers()
        {
            List<User> userList = _userDAL.GetAllUsers();
            List<UserDTO> listUserDTO = mapper.Map<List<User>, List<UserDTO>>(userList);
            return listUserDTO;
        }

        public UserDTO GetUserByID(string idUser)
        {
            User user = _userDAL.GetUserByID(idUser);
            UserDTO UserDTO = mapper.Map<User, UserDTO>(user);
            return UserDTO;
        }

        public bool AddUser(UserDTO userDTO)
        {
            User currentUser = mapper.Map<UserDTO, User>(userDTO);
            bool isSucsess = _userDAL.AddUser(currentUser);
            return isSucsess;
        }

        public bool UpdateUser(UserDTO userDTO)
        {
            User currentUser = mapper.Map<UserDTO, User>(userDTO);
            bool isSucsess = _userDAL.UpdateUser(currentUser.Id, currentUser);
            return isSucsess;
        }

        public bool DeleteUser(UserDTO userDTO)
        {
            string idToDelete = userDTO.Id;
            bool isSucsess = _userDAL.DeleteUser(idToDelete);
            return isSucsess;
        }
    }
}
