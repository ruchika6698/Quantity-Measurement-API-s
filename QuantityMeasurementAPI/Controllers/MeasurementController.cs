using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using CommanLayer;
using CommanLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace QuantityMeasurementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementController : ControllerBase
    {
        private IConfiguration _config;
        IQuantityMeasurementBL BusinessLayer;

        public MeasurementController(IQuantityMeasurementBL BusinessDependencyInjection, IConfiguration config)
        {
            BusinessLayer = BusinessDependencyInjection;
            _config = config;
        }

        /// <summary>
        /// Method to Add Conversion Detail
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("addnewentry")]
        public IActionResult Convert([FromBody]Quantity  Info)
        {
            try
            {
                var result = BusinessLayer.Convert(Info);
                //if entry is not equal to null
                if (!result.Equals(null))
                {
                    var status = "True";
                    var Message = "New Entry Added Sucessfully";
                    return this.Ok(new { status, Message, data = Info });
                }
                else                                              //Entry is not added
                {
                    var status = "False";
                    var Message = "New Entry is not Added";
                    return this.BadRequest(new { status, Message, data = Info });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}