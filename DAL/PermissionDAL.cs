using Entities.Models;
using Microsoft.EntityFrameworkCore;
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

        public List<Permission> GetAllPermissionForBudget(int idBudget)
        {
            try
            {
                List<Permission> permissionList = _context.Permissions.Where(p => p.IdBudget == idBudget).ToList();
                return permissionList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetLevelPermissionForBudgetByID(int idBudget, string id)
        {
            try
            {

                var permission = _context.Permissions.SingleOrDefault(p => p.IdBudget == idBudget && p.IdUser.Equals(id));

                if (permission != null)
                {
                    return permission.PermissionLevel;
                }
                else
                {
                    return 8;
                }
              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddPermission(Permission permission)
        {
            var per = _context.Permissions.Where(p => p.IdUser.Equals(permission.IdUser) && p.IdBudget.Equals(permission.IdBudget)).AsNoTracking().FirstOrDefault();
            if (per == null)
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
            else
                return false;
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
