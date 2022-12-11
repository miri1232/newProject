﻿using DAL.Models;
using System.Collections.Generic;

namespace DAL
{
    public interface IUserDAL
    {
         List<User> GetAllUsers();
         User GetUserByID(string idUser);
         bool AddUser(User user);
         bool UpdateUser(string id, User user);
         bool DeleteUser(string id);
       
    }
}