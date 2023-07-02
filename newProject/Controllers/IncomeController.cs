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
        [Route("GetAllIncomes")]
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
        //שליפה לפי תקציב
        [HttpGet]
        [Route("GetIncomesByBudget/{idBudget}")]
        public IActionResult GetIncomesByBudget(int idBudget)
        {
            try
            {
                return Ok(_incomeBL.GetIncomesByBudget(idBudget));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetIncomesByBudgetGroup/{idBudget}")]
        public IActionResult GetIncomesByBudgetGroup(int idBudget)
        {
            try
            {
                return Ok(_incomeBL.GetIncomesByBudgetGroup(idBudget));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        //שליפה לפי טווח תאריכים
        [HttpGet]
        [Route("IncomesByDate")]
        public IActionResult GetIncomesByDate(DateTime start, DateTime end)
        {
            try
            {
                return Ok(_incomeBL.GetIncomesByDate(start, end));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //שליפה לפי טווח סכום
        [HttpGet]
        [Route("IncomesBySum")]
        public IActionResult GetIncomesBySum(double min, double max)
        {
            try
            {
                return Ok(_incomeBL.GetIncomesBySum( min,  max));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //שליפה לפי קטגוריה
        [HttpGet]
        [Route("IncomesByCategory")]
        public IActionResult GetIncomesByCategory(int category)
        {
            try
            {
                return Ok(_incomeBL.GetIncomesByCategory(category));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //שליפה לפי מקור הכנסה
        [HttpGet]
        [Route("IncomesBySourceOfIncome")]
        public IActionResult GetIncomesBySourceOfIncome(int sourceOfIncome)
        {
            try
            {
                return Ok(_incomeBL.GetIncomesBySourceOfIncome(sourceOfIncome));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //שליפה לפי סטטוס
        [HttpGet]
        [Route("IncomesByStatus")]
        public IActionResult GetIncomesByStatus(int status)
        {
            try
            {
                return Ok(_incomeBL.GetIncomesByStatus(status));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        //שליפה לפי כל הסינונים באמצעות אובייקט
        [HttpPost]
        [Route("SearchIncomesObject")]
        public IActionResult SearchExpensesObject([FromBody] SearchDTO searchDTO)
        {
            try
            {
                return Ok(_incomeBL.SearchIncomesObject(searchDTO));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //שליפת דוחות בסיכום קטגוריה+תת קטגוריה בטווח תאריכים
        [HttpPost]
        [Route("ReportIncomes")]
        public IActionResult ReportIncomes([FromBody] SearchDTO searchDTO)
        {
            //int idBudget=0; DateTime start=new DateTime(); DateTime end = new DateTime(); int status=0;
            try
            {
                return Ok(_incomeBL.ReportIncomes(searchDTO));
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
