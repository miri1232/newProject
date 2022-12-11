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
                return _context.User.ToList();
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
                User user = _context.User.Where(p => p.Id == idUser).FirstOrDefault();
                return user;
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
                _context.User.Add(user);
                _context.SaveChanges();
                return true;
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
                User currentUser = _context.User.SingleOrDefault(x => x.Id == id);
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
                User currentUser = _context.User.SingleOrDefault(x => x.Id == id);
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
