using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class PermissionDAL : IPermissionDAL
    {
        dbBudgetContext _context = new dbBudgetContext();

        public List<Permission> GetAllPermission()
        {
            try
            {
                return _context.Permissions.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddPermission(Permission permission)
        {
            try
            {
                _context.Permissions.Add(permission);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool UpdatePermission(int id, Permission permission)
        {
            try
            {
                Permission currentPermissions = _context.Permissions.SingleOrDefault(x => x.Id == id);
                _context.Entry(currentPermissions).CurrentValues.SetValues(permission);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeletePermissions(int id)
        {
            try
            {
                Permission currentPermission = _context.Permissions.SingleOrDefault(x => x.Id == id);
                _context.Remove(currentPermission);
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
