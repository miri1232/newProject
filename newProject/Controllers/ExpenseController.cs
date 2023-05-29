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

        //שליפה לפי תקציב
        [HttpGet]
        [Route("GetExpensesByBudget/{idBudget}")]
        public IActionResult GetExpensesByBudget(int idBudget)
        {
            try
            {
                return Ok(_expenseBL.GetExpensesByBudget(idBudget));
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
        [Route("GetExpensesByCategory")]
        public IActionResult GetExpensesByCategory(int category)
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

        //שליפה לפי תת קטגוריה
        [HttpGet]
        [Route("GetExpensesBySubcategory")]
        public IActionResult GetExpensesBySubcategory(int subcategory)
        {
            try
            {
                return Ok(_expenseBL.GetExpensesBySubcategory(subcategory));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //שליפה לפי אופן התשלום
        [HttpGet]
        [Route("ExpensesByPaymentMethod")]
        public IActionResult GetExpensesByPaymentMethod(int paymentMethod)
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
        public IActionResult GetExpensesByStatus(int status)
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

        //שליפה לפי כל הסינונים
        [HttpGet]
        [Route("SearchExpenses")]
        public IActionResult SearchExpenses(DateTime start, DateTime end, double min, double max, int category, int Subcategory, int paymentMethod, int status)
        {
            try
            {
                return Ok(_expenseBL.SearchExpenses(start, end, min, max, category, Subcategory, paymentMethod, status));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //הוספה
        [HttpPost]
        [Route("AddExpense")]
        public ActionResult<ExpenseDTO> AddExpense([FromBody] ExpenseDTO expenseDTO)
        {
            try
            {
                ExpenseDTO exp= _expenseBL.AddExpense(expenseDTO);
                return Ok(exp);
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
                ExpenseDTO exp = _expenseBL.UpdateExpense(expenseDTO);
                return Ok(exp);
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

     
        ////שליפת דוחות בסיכום תת קטגוריה
        //[HttpGet]
        //[Route("ReportSubCategoryExpenses/{idBudget}")]
        //public IActionResult ReportSubCategoryExpenses(int idBudget)
        //{
        //    try
        //    {
        //        return Ok(_expenseBL.ReportSubCategoryExpenses(idBudget));
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //}

        // //שליפת דוחות בסיכום קטגוריה
        //[HttpGet]
        //[Route("ReportCategoryExpenses/{idBudget}")]
        //public IActionResult ReportCategoryExpenses(int idBudget)
        //{
        //    try
        //    {
        //        return Ok(_expenseBL.ReportCategoryExpenses(idBudget));
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //}

   //שליפת דוחות בסיכום קטגוריה+תת קטגוריה
        [HttpGet]
        [Route("ReportExpenses2/{idBudget}")]

        public IActionResult ReportExpenses2(int idBudget)
        {
            try
            {
                return Ok(_expenseBL.ReportExpenses2(idBudget));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        //שליפת דוחות בסיכום קטגוריה+תת קטגוריה בטווח תאריכים
        [HttpGet]
        [Route("ReportExpenses3/{idBudget}/{start}/{end}/{status}")]

        public IActionResult ReportExpenses3(int idBudget, DateTime start, DateTime end, int status)
        {
            try
            {
                return Ok(_expenseBL.ReportExpenses3(idBudget, start, end, status));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}

