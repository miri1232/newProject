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
    public class ExpenseController : ControllerBase
    {
        private IExpenseBL _expenseBL;

        public ExpenseController(IExpenseBL expenseBL)
        {
            _expenseBL = expenseBL;
        }

        //שליפה
        [HttpGet]
        [Route("Expenses")]
        public IActionResult GetAllExpenses()
        {
            try
            {
                return Ok(_expenseBL.GetAllExpenses());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //הוספה
        [HttpPost]
        [Route("AddExpense")]
        public ActionResult<bool> AddExpense([FromBody] ExpenseDTO expenseDTO)
        {
            try
            {
                bool x = _expenseBL.AddExpense(expenseDTO);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //עידכון
        [HttpPut]
        [Route("UpdateExpense")]
        public ActionResult<bool> UpdateExpense([FromBody] ExpenseDTO expenseDTO)
        {
            try
            {
                bool x = _expenseBL.UpdateExpense(expenseDTO);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //מחיקה
        [HttpDelete]
        [Route("DeleteExpense")]
        public ActionResult<bool> DeleteExpense([FromBody] ExpenseDTO expenseDTO)
        {
            try
            {
                bool x = _expenseBL.DeleteExpense(expenseDTO);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

