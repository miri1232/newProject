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
    public class CategoryController : ControllerBase
    {
        private ICategoryBL _categoryBL;

        public CategoryController(ICategoryBL categoryBL)
        {
            _categoryBL = categoryBL;
        }

        //שליפה
        [HttpGet]
        [Route("GetAllCategory")]
        public IActionResult GetAllCategory()
        {
            try
            {
                return Ok(_categoryBL.GetAllCategory());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //שליפה לפי ID
        [HttpGet]
        [Route("GetCategoryByID")]
        public IActionResult GetCategoryByID(int idCategory)
        {
            try
            {

               return Ok(_categoryBL.GetCategoryByID(idCategory));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //הוספה
        [HttpPost]
        [Route("AddCategory")]
        public ActionResult<bool> AddCategory([FromBody] CategoryDTO categoryDTO)
        {
            try
            {
                bool x = _categoryBL.AddCategory(categoryDTO);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //עידכון
        [HttpPut]
        [Route("UpdateCategory")]
        public ActionResult<bool> UpdateCategory([FromBody] CategoryDTO categoryDTO)
        {
            try
            {
                bool x = _categoryBL.UpdateCategory(categoryDTO);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //מחיקה
        [HttpDelete]
        [Route("DeleteCategory")]
        public ActionResult<bool> DeleteCategory([FromBody] CategoryDTO categoryDTO)
        {
            try
            {
                bool x = _categoryBL.DeleteCategory(categoryDTO);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
