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
    public class IncomeController : ControllerBase
    {
        private IIncomeBL _incomeBL;

        public IncomeController(IIncomeBL incomeBL)
        {
            _incomeBL = incomeBL;
        }

        //שליפה
        [HttpGet]
        [Route("Income")]
        public IActionResult GetAllIncomes()
        {
            try
            {
                return Ok(_incomeBL.GetAllIncomes());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //הוספה
        [HttpPost]
        [Route("AddIncome")]
        public ActionResult<bool> AddIncome([FromBody] IncomeDTO incomeDTO)
        {
            try
            {
                bool x = _incomeBL.AddIncome(incomeDTO);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //עידכון
        [HttpPut]
        [Route("UpdateIncome")]
        public ActionResult<bool> UpdateIncome([FromBody] IncomeDTO incomeDTO)
        {
            try
            {
                bool x = _incomeBL.UpdateIncome(incomeDTO);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //מחיקה
        [HttpDelete]
        [Route("DeleteIncome")]
        public ActionResult<bool> DeleteIncome([FromBody] IncomeDTO incomeDTO)
        {
            try
            {
                bool x = _incomeBL.DeleteIncome(incomeDTO);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
