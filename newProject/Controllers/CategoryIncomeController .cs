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
    public class CategoryIncomeController : ControllerBase
    {
        private ICategoryIncomeBL _categoryIncomeBL;

        public CategoryIncomeController(ICategoryIncomeBL categoryIncomeBL)
        {
            _categoryIncomeBL = categoryIncomeBL;
        }

        //שליפה
        [HttpGet]
        [Route("GetAllCategoryIncome")]
        public IActionResult GetAllCategoryIncome()
        {
            try
            {
                return Ok(_categoryIncomeBL.GetAllCategoryIncome());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //הוספה
        [HttpPost]
        [Route("AddCategoryIncome")]
        public ActionResult<bool> AddCategoryIncome([FromBody] CategoryIncomeDTO categoryIncomeDTO)
        {
            try
            {
                bool x = _categoryIncomeBL.AddCategoryIncome(categoryIncomeDTO);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //עידכון
        [HttpPut]
        [Route("UpdateCategoryIncome")]
        public ActionResult<bool> UpdateCategoryIncome([FromBody] CategoryIncomeDTO categoryIncomeDTO)
        {
            try
            {
                bool x = _categoryIncomeBL.UpdateCategoryIncome(categoryIncomeDTO);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //מחיקה
        [HttpDelete]
        [Route("DeleteCategoryIncome")]
        public ActionResult<bool> DeleteCategoryIncome([FromBody] CategoryIncomeDTO categoryIncomeDTO)
        {
            try
            {
                bool x = _categoryIncomeBL.DeleteCategoryIncome(categoryIncomeDTO);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
