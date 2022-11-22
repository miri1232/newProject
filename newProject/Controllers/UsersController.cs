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
        public class UsersController : ControllerBase
        {
            private IUsersBL _usersBL;

            public UsersController(IUsersBL usersBL)
            {
                _usersBL = usersBL;
            }

            //שליפה
            [HttpGet]
            [Route("Users")]
            public IActionResult GetAllUsers()
            {
                try
                {
                    return Ok(_usersBL.GetAllUsers());
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }

            //הוספה
            [HttpPost]
            [Route("AddUsers")]
            public ActionResult<bool> AddUsers([FromBody] UsersDTO usersDTO)
            {
                try
                {
                    bool x = _usersBL.AddUsers(usersDTO);
                    return Ok(x);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }

            //עידכון
            [HttpPut]
            [Route("UpdateUsers")]
            public ActionResult<bool> UpdateUsers([FromBody] UsersDTO usersDTO)
            {
                try
                {
                    bool x = _usersBL.UpdateUsers(usersDTO);
                    return Ok(x);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }

            //מחיקה
            [HttpDelete]
            [Route("DeleteUsers")]
            public ActionResult<bool> DeleteUsers([FromBody] UsersDTO usersDTO)
            {
                try
                {
                    bool x = _usersBL.DeleteUsers(usersDTO);
                    return Ok(x);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
        }
    }

