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
        [Route("GetAllExpenses")]
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
        //שליפה לפי טווח תאריכים
        [HttpGet]
        [Route("ExpensesByDate")]
        public IActionResult GetExpensesByDate(DateTime start, DateTime end)
        {
            try
            {
                return Ok(_expenseBL.GetExpensesByDate(start, end));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //שליפה לפי טווח סכום
        [HttpGet]
        [Route("ExpensesBySum")]
        public IActionResult GetExpensesBySum(double min, double max)
        {
            try
            {
                return Ok(_expenseBL.GetExpensesBySum( min,  max));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //שליפה לפי קטגוריה
        [HttpGet]
        [Route("ExpensesByCategory")]
        public IActionResult GetExpensesByCategory(string category)
        {
            try
            {
                return Ok(_expenseBL.GetExpensesByCategory(category));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //שליפה לפי אופן התשלום
        [HttpGet]
        [Route("ExpensesByPaymentMethod")]
        public IActionResult GetExpensesByPaymentMethod(string paymentMethod)
        {
            try
            {
                return Ok(_expenseBL.GetExpensesByPaymentMethod(paymentMethod));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //שליפה לפי סטטוס
        [HttpGet]
        [Route("ExpensesByPaymentStatus")]
        public IActionResult GetExpensesByStatus(string status)
        {
            try
            {
                return Ok(_expenseBL.GetExpensesByStatus(status));
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

