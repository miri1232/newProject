using BL;
using DTO.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace newProject.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserBL _userBL;

        public UserController(IUserBL userBL)
        {
            _userBL = userBL;
        }

        //שליפה
        [HttpGet]
        [Route("User")]
        public IActionResult GetAllUsers()
        {
            try
            {
                return Ok(_userBL.GetAllUsers());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

         //אימות משתמש
        [HttpGet]
        [Route("Login")]
        public IActionResult LoginUserByID(string idUser, string password)
        {
            try
            {
                return Ok(_userBL.LoginUserByID( idUser,  password));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        //שליפת ערך יחיד
        [HttpGet]
        [Route("UserByID")]
        public IActionResult GetUserByID(string idUser)
        {
            try
            {
                return Ok(_userBL.GetUserByID(idUser));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        //הוספה
        [HttpPost]
        [Route("AddUser")]
        public ActionResult<bool> AddUser([FromBody] UserDTO userDTO)
        {
            try
            {
                bool x = _userBL.AddUser(userDTO);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //עידכון
        [HttpPut]
        [Route("UpdateUser")]
        public ActionResult<bool> UpdateUser([FromBody] UserDTO userDTO)
        {
            try
            {
                bool x = _userBL.UpdateUser(userDTO);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //מחיקה
        [HttpDelete]
        [Route("DeleteUser")]
        public ActionResult<bool> DeleteUsers([FromBody] UserDTO userDTO)
        {
            try
            {
                bool x = _userBL.DeleteUser(userDTO);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

