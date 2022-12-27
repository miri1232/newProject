using DTO.Models;
using System.Collections.Generic;

namespace BL
{
    public interface IUserBL
    {
       List<UserDTO> GetAllUsers();
       bool LoginUserByID(string idUser, string password);
       UserDTO GetUserByID(string idUser);
       bool AddUser(UserDTO userDTO);
       bool UpdateUser(UserDTO userDTO);
       bool DeleteUser(UserDTO userDTO);
    }
}