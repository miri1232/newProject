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
    public class MessagesForUserController : ControllerBase
    {
        private IMessagesForUserBL _messagesForUserBL;

        public MessagesForUserController(IMessagesForUserBL messagesForUserBL)
        {
            _messagesForUserBL = messagesForUserBL;
        }

        //שליפה
        [HttpGet]
        [Route("MessagesForUser")]
        public IActionResult GetAllMessagesForUser()
        {
            try
            {
                return Ok(_messagesForUserBL.GetAllMessagesForUser());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //הוספה
        [HttpPost]
        [Route("AddMessagesForUser")]
        public ActionResult<bool> AddMessagesForUser([FromBody] MessagesForUserDTO messagesForUserDTO)
        {
            try
            {
                bool x = _messagesForUserBL.AddMessagesForUser(messagesForUserDTO);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //עידכון
        [HttpPut]
        [Route("UpdateMessagesForUser")]
        public ActionResult<bool> UpdateMessagesForUser([FromBody] MessagesForUserDTO messagesForUserDTO)
        {
            try
            {
                bool x = _messagesForUserBL.UpdateMessagesForUser(messagesForUserDTO);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //מחיקה
        [HttpDelete]
        [Route("DeleteMessagesForUser")]
        public ActionResult<bool> DeleteMessagesForUser([FromBody] MessagesForUserDTO messagesForUserDTO)
        {
            try
            {
                bool x = _messagesForUserBL.DeleteMessagesForUser(messagesForUserDTO);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
