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
    public class UsersBL : IUsersBL
    {
        private IUsersDAL _usersDAL;
        IMapper mapper;

        public UsersBL(IUsersDAL usersDAL)
        {
            _usersDAL = usersDAL;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            mapper = config.CreateMapper();
        }

        public List<UsersDTO> GetAllUsers()
        {
            List<Users> userList = _usersDAL.GetAllUsers();
            List<UsersDTO> listUserDTO = mapper.Map<List<Users>, List<UsersDTO>>(userList);
            return listUserDTO;
        }

        public bool AddUsers(UsersDTO userDTO)
        {
            Users currentUsers = mapper.Map<UsersDTO, Users>(userDTO);
            bool isSucsess = _usersDAL.AddUsers(currentUsers);
            return isSucsess;
        }

        public bool UpdateUsers(UsersDTO usersDTO)
        {
            Users currentUsers = mapper.Map<UsersDTO, Users>(usersDTO);
            bool isSucsess = _usersDAL.UpdateUsers(currentUsers.Id, currentUsers);
            return isSucsess;
        }

        public bool DeleteUsers(UsersDTO usersDTO)
        {
            string idToDelete = usersDTO.Id;
            bool isSucsess = _usersDAL.DeleteUsers(idToDelete);
            return isSucsess;
        }
    }
}
