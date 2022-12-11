using DTO.Models;
using System.Collections.Generic;

namespace BL
{
    public interface IUserBL
    {
       List<UserDTO> GetAllUsers();
       UserDTO GetUserByID(string idUser);
       bool AddUser(UserDTO userDTO);
       bool UpdateUser(UserDTO userDTO);
       bool DeleteUser(UserDTO userDTO);
    }
}