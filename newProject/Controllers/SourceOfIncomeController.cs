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
    public class SourceOfIncomeController : ControllerBase
    {
        private ISourceOfIncomeBL _sourceOfIncomeBL;

        public SourceOfIncomeController(ISourceOfIncomeBL sourceOfIncomeBL)
        {
            _sourceOfIncomeBL = sourceOfIncomeBL;
        }

        //שליפה
        [HttpGet]
        [Route("GetAllSourceOfIncomes")]
        public IActionResult GetAllSourceOfIncomes()
        {
            try
            {
                return Ok(_sourceOfIncomeBL.GetAllSourceOfIncomes());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //שליפת ערך יחיד לפי ID 
        [HttpGet]
        [Route("GetSourceOfIncomeByID")]
        public IActionResult GetSourceOfIncomeByID(int categoryIncome)
        {
            try
            {
                return Ok(_sourceOfIncomeBL.GetSourceOfIncomeByID(categoryIncome));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //הוספה
        [HttpPost]
        [Route("AddSourceOfIncome")]
        public ActionResult<bool> AddSourceOfIncome([FromBody] SourceOfIncomeDTO sourceOfIncomeDTO)
        {
            try
            {
                bool x = _sourceOfIncomeBL.AddSourceOfIncome(sourceOfIncomeDTO);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //עידכון
        [HttpPut]
        [Route("UpdateSourceOfIncome")]
        public ActionResult<bool> UpdateSourceOfIncome([FromBody] SourceOfIncomeDTO sourceOfIncomeDTO)
        {
            try
            {
                bool x = _sourceOfIncomeBL.UpdateSourceOfIncome(sourceOfIncomeDTO);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //מחיקה
        [HttpDelete]
        [Route("DeleteSourceOfIncome")]
        public ActionResult<bool> DeleteSourceOfIncome([FromBody] SourceOfIncomeDTO sourceOfIncomeDTO)
        {
            try
            {
                bool x = _sourceOfIncomeBL.DeleteSourceOfIncome(sourceOfIncomeDTO);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

