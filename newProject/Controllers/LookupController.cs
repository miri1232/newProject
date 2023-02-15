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
        [Route("GetAllBank")]
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
        [Route("GetAllBankOfBudget/{idBudget}")]
        public IActionResult GetAllBankOfBudget(int idBudget)
        {
            try
            {
                return Ok(_lookupBL.GetAllBankOfBudget(idBudget));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet]
        [Route("GetAllPermissionLevel")]
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
        [HttpGet]
        [Route("GetAllStatus")]
        public IActionResult GetAllStatus()
        {
            try
            {
                return Ok(_lookupBL.GetAllStatus());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAllPaymentMethod")]
        public IActionResult GetAllPaymentMethod()
        {
            try
            {
                return Ok(_lookupBL.GetAllPaymentMethod());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAllTypeBudget")]
        public IActionResult GetAllTypeBudget()
        {
            try
            {
                return Ok(_lookupBL.GetAllTypeBudget());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}
