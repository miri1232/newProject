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
    public class MessageController : ControllerBase
    {
        private IMessageBL _messageBL;

        public MessageController(IMessageBL messageBL)
        {
            _messageBL = messageBL;
        }

        //שליפה
        [HttpGet]
        [Route("Messages")]
        public IActionResult GetAllMessages()
        {
            try
            {
                return Ok(_messageBL.GetAllMessages());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //הוספה
        [HttpPost]
        [Route("AddMessage")]
        public ActionResult<bool> AddMessage([FromBody] MessageDTO messageDTO)
        {
            try
            {
                bool x = _messageBL.AddMessage(messageDTO);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //עידכון
        [HttpPut]
        [Route("UpdateMessage")]
        public ActionResult<bool> UpdateMessage([FromBody] MessageDTO messageDTO)
        {
            try
            {
                bool x = _messageBL.UpdateMessage(messageDTO);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //מחיקה
        [HttpDelete]
        [Route("DeleteMessage")]
        public ActionResult<bool> DeleteMessage([FromBody] MessageDTO messageDTO)
        {
            try
            {
                bool x = _messageBL.DeleteMessage(messageDTO);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
