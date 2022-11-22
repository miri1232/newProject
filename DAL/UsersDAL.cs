using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UsersDAL : IUsersDAL
    {
        dbBudgetContext _context = new dbBudgetContext();

        public List<Users> GetAllUsers()
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

        public bool AddUsers(Users user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateUsers(string id, Users user)
        {
            try
            {
                Users currentUser = _context.Users.SingleOrDefault(x => x.Id == id);
                _context.Entry(currentUser).CurrentValues.SetValues(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteUsers(string id)
        {
            try
            {
                Users currentUser = _context.Users.SingleOrDefault(x => x.Id == id);
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
