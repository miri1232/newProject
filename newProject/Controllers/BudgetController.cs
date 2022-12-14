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
        public class BudgetController : ControllerBase
        {
            private IBudgetBL _budgetBL;

            public BudgetController(IBudgetBL budgetBL)
            {
                _budgetBL = budgetBL;
            }

            //שליפה
            [HttpGet]
            [Route("GetAllBudgets")]
            public IActionResult GetAllBudgets()
            {
                try
                {
                    return Ok(_budgetBL.GetAllBudgets());
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }

        //שליפת ערך יחיד
        [HttpGet]
        [Route("BudgetByID")]
        public IActionResult GetBudgetByID(int idBudget)
        {
            try
            {
                return Ok(_budgetBL.GetBudgetByID(idBudget));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //הוספה
        [HttpPost]
            [Route("AddBudget")]
            public ActionResult<bool> AddBudget([FromBody] BudgetDTO budgetDTO)
            {
                try
                {
                    bool x = _budgetBL.AddBudget(budgetDTO);
                    return Ok(x);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }

            //עידכון
            [HttpPut]
            [Route("UpdateBudget")]
            public ActionResult<bool> UpdateBudget([FromBody] BudgetDTO budgetDTO)
            {
                try
                {
                    bool x = _budgetBL.UpdateBudget(budgetDTO);
                    return Ok(x);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }

            //מחיקה
            [HttpDelete]
            [Route("DeleteBudget")]
            public ActionResult<bool> DeleteBudget([FromBody] BudgetDTO budgetDTO)
            {
                try
                {
                    bool x = _budgetBL.DeleteBudget(budgetDTO);
                    return Ok(x);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
        }
}

