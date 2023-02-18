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
    public class BankOfBudgetController : ControllerBase
    {
        private IBankOfBudgetBL _bankOfBudgetBL;

        public BankOfBudgetController(IBankOfBudgetBL bankOfBudgetBL)
        {
            _bankOfBudgetBL = bankOfBudgetBL;
        }

        //שליפה
        [HttpGet]
        [Route("GetAllBankOfBudgets")]
        public IActionResult GetAllBankOfBudgets()
        {
            try
            {
                return Ok(_bankOfBudgetBL.GetAllBankOfBudgets());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //שליפת ערך יחיד לפי ID תקציב
        [HttpGet]
        [Route("GetBankOfBudgetByID")]
        public IActionResult GetBankOfBudgetByID(int idBankOfBudget)
        {
            try
            {
                return Ok(_bankOfBudgetBL.GetBankOfBudgetByID(idBankOfBudget));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        //שליפת רשימת בנקים לפי מספר תקציב
        [HttpGet]
        [Route("GetBankOfBudgetByIdBudget/{idBudget}")]
        public IActionResult GetBankOfBudgetByIdBudget(int idBudget)
        {
            try
            {
                return Ok(_bankOfBudgetBL.GetBankOfBudgetByIdBudget(idBudget));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //הוספה
        [HttpPost]
        [Route("AddBankOfBudget")]
        public ActionResult<bool> AddBankOfBudget([FromBody] BankOfBudgetDTO bankOfBudgetDTO)
        {
            try
            {
                bool x = _bankOfBudgetBL.AddBankOfBudget(bankOfBudgetDTO);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //עידכון
        [HttpPut]
        [Route("UpdateBankOfBudget")]
        public ActionResult<bool> UpdateBankOfBudget([FromBody] BankOfBudgetDTO bankOfBudgetDTO)
        {
            try
            {
                bool x = _bankOfBudgetBL.UpdateBankOfBudget(bankOfBudgetDTO);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //מחיקה
        [HttpDelete]
        [Route("DeleteBankOfBudget")]
        public ActionResult<bool> DeleteBankOfBudget([FromBody] BankOfBudgetDTO bankOfBudgetDTO)
        {
            try
            {
                bool x = _bankOfBudgetBL.DeleteBankOfBudget(bankOfBudgetDTO);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

