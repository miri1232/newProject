using DAL.Models;
using System.Collections.Generic;

namespace DAL
{
    public interface IUsersDAL
    {
         List<Users> GetAllUsers();
         bool AddUsers(Users user);
         bool UpdateUsers(string id, Users user);
         bool DeleteUsers(string id);
       
    }
}