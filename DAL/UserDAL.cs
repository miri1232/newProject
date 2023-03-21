using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDAL : IUserDAL
    {
        dbBudgetContext _context = new dbBudgetContext();

        public List<User> GetAllUsers()
        {
            try
            {
                return _context.Users.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User GetUserByID(string idUser)
        {
            try
            {
                User user = _context.Users.Where(p => p.Id == idUser).FirstOrDefault();
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool LoginUserByID(string idUser, string password)
        {
            try
            {
                User user = GetUserByID(idUser);
                if(user == null)
                {
                    return false;
                }
                if (user.Password.Equals(password))
                    return true;
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public bool AddUser(User user)
        {
            try
            {
                User currentUser = _context.Users.SingleOrDefault(x => x.Id == user.Id);
                if (currentUser == null) {
                _context.Users.Add(user);
                _context.SaveChanges();
                  return true;
                }
                else
                {
                Console.WriteLine("המשתמש קיים במערכת");
                return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateUser(string id, User user)
        {
            try
            {
                User currentUser = _context.Users.SingleOrDefault(x => x.Id == id);
                _context.Entry(currentUser).CurrentValues.SetValues(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteUser(string id)
        {
            try
            {
                User currentUser = _context.Users.SingleOrDefault(x => x.Id == id);
                _context.Remove(currentUser);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
