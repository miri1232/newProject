using BL;
using DTO.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newProject.Controllers
{
    public class BudgetController
    {

        [Route("api/[controller]")]
        [ApiController]
        public class FlightsController : ControllerBase
        {
            private IBudgetBL _budgetBL;

            public FlightsController(IBudgetBL budgetBL)
            {
                _budgetBL = budgetBL;
            }

            //שליפה
            [HttpGet]
            [Route("Budget")]
            public IActionResult GetAllBudget()
            {
                try
                {
                    return Ok(_budgetBL.GetAllBudget());
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
}
