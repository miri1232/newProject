using DTO.Models;
using System.Collections.Generic;

namespace BL
{
    public interface IUsersBL
    {
       List<UsersDTO> GetAllUsers();
       bool AddUsers(UsersDTO userDTO);
       bool UpdateUsers(UsersDTO usersDTO);
       bool DeleteUsers(UsersDTO usersDTO);
    }
}