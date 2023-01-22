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
    public class SubcategoryController : ControllerBase
    {
        private ISubcategoryBL _subcategoryBL;

        public SubcategoryController(ISubcategoryBL subcategoryBL)
        {
            _subcategoryBL = subcategoryBL;
        }

        //שליפה
        [HttpGet]
        [Route("GetAllSubcategory")]
        public IActionResult GetAllSubcategory()
        {
            try
            {
                return Ok(_subcategoryBL.GetAllSubcategory());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //הוספה
        [HttpPost]
        [Route("AddSubcategory")]
        public ActionResult<bool> AddSubcategory([FromBody] SubcategoryDTO subcategoryDTO)
        {
            try
            {
                bool x = _subcategoryBL.AddSubcategory(subcategoryDTO);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //עידכון
        [HttpPut]
        [Route("UpdateSubcategory")]
        public ActionResult<bool> UpdateSubcategory([FromBody] SubcategoryDTO subcategoryDTO)
        {
            try
            {
                bool x = _subcategoryBL.UpdateSubcategory(subcategoryDTO);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //מחיקה
        [HttpDelete]
        [Route("DeleteSubcategory")]
        public ActionResult<bool> DeleteSubcategory([FromBody] SubcategoryDTO subcategoryDTO)
        {
            try
            {
                bool x = _subcategoryBL.DeleteSubcategory(subcategoryDTO);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
