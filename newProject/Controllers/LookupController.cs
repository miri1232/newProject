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
    public class LookupController : ControllerBase
    {

        private ILookupBL _lookupBL;
      

        public LookupController(ILookupBL lookupBL)
            {
            _lookupBL = lookupBL;
            }

   
        [HttpGet]
        [Route("LookupBank")]
        public IActionResult GetAllBank()
        {
            try
            {
                return Ok(_lookupBL.GetAllBank());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("LookupBankOfBudget")]
        public IActionResult GetAllBankOfBudget()
        {
            try
            {
                return Ok(_lookupBL.GetAllBankOfBudget());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("LookupPermission")]
        public IActionResult GetAllPermission()
        {
            try
            {
                return Ok(_lookupBL.GetAllPermission());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("LookupPermissionLevel")]
        public IActionResult GetAllPermissionLevel()
        {
            try
            {
                return Ok(_lookupBL.GetAllPermissionLevel());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
