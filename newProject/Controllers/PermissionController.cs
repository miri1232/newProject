using BL;
using DTO.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private IPermissionBL _permissionBL;

        public PermissionController(IPermissionBL permissionBL)
        {
            _permissionBL = permissionBL;
        }
        //שליפה
        [HttpGet]
        [Route("GetAllPermission")]
        public IActionResult GetAllPermission()
        {
            try
            {
                return Ok(_permissionBL.GetAllPermission());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //שליפת הרשאות לפי תקציב
        [HttpGet]
        [Route("GetAllPermissionForBudget")]
        public IActionResult GetAllPermissionForBudget(int idBudget)
        {
            try
            {
                return Ok(_permissionBL.GetAllPermissionForBudget(idBudget));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //שליפת רמת הרשאה למשתמש בתוך תקציב
         [HttpGet]
        [Route("GetLevelPermissionForBudgetByID")]
        public IActionResult GetLevelPermissionForBudgetByID(int idBudget, string id)
        {
            try
            {
                return Ok(_permissionBL.GetLevelPermissionForBudgetByID(idBudget,id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        //הוספה
        [HttpPost]
        [Route("AddPermission")]
        public ActionResult<bool> AddPermission([FromBody] PermissionDTO permissionDTO)
        {
            try
            {
                bool x = _permissionBL.AddPermission(permissionDTO);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //עידכון
        [HttpPut]
        [Route("UpdatePermission")]
        public ActionResult<bool> UpdatePermission([FromBody] PermissionDTO permissionDTO)
        {
            try
            {
                bool x = _permissionBL.UpdatePermission(permissionDTO);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //מחיקה
        [HttpDelete]
        [Route("DeletePermissions")]
        public ActionResult<bool> DeletePermissions([FromBody] PermissionDTO permissionDTO)
        {
            try
            {
                bool x = _permissionBL.DeletePermission(permissionDTO);  
                return Ok(x);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
