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
    public class NumberPaymentsController : ControllerBase
    {
        private INumberPaymentsBL _numberPaymentsBL;

        public NumberPaymentsController(INumberPaymentsBL numberPaymentsBL)
        {
            _numberPaymentsBL = numberPaymentsBL;
        }

        //שליפה
        [HttpGet]
        [Route("GetAllNumberPayments")]
        public IActionResult GetAllNumberPayments()
        {
            try
            {
                return Ok(_numberPaymentsBL.GetAllNumberPayments());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //הוספה
        [HttpPost]
        [Route("AddNumberPayments")]
        public ActionResult<bool> AddNumberPayments([FromBody] NumberPaymentsDTO numberPaymentsDTO)
        {
            try
            {
                bool x = _numberPaymentsBL.AddNumberPayments(numberPaymentsDTO);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //עידכון
        [HttpPut]
        [Route("UpdateNumberPayments")]
        public ActionResult<bool> UpdateNumberPayments([FromBody] NumberPaymentsDTO numberPaymentsDTO)
        {
            try
            {
                bool x = _numberPaymentsBL.UpdateNumberPayments(numberPaymentsDTO);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //מחיקה
        [HttpDelete]
        [Route("DeleteNumberPayments")]
        public ActionResult<bool> DeleteNumberPayments([FromBody] NumberPaymentsDTO numberPaymentsDTO)
        {
            try
            {
                bool x = _numberPaymentsBL.DeleteNumberPayments(numberPaymentsDTO);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

