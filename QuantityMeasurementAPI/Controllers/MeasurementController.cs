using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using CommanLayer;
using CommanLayer.CustomException;
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
        /// <returns> add conversion in database </returns>
        [HttpPost]
        public IActionResult Convert([FromBody]Quantity  Info)
        {
            try
            {
                var result = BusinessLayer.Convert(Info);
                if (result == null)
                {
                    return BadRequest(new { Success = false, message = CustomException.ExceptionType.INPUT_NULL });
                }
                //if entry is not equal to null
                if (!result.Equals(null))
                {
                    var Success = "True";
                    var Message = "New Entry Added Sucessfully";
                    return this.Ok(new { Success, Message, data = Info });
                }
                else                                              //Entry is not added
                {
                    var Success = "False";
                    var Message = "New Entry is not Added";
                    return this.BadRequest(new { Success, Message, data = Info });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        ///  API for Delete data
        /// </summary>
        /// <param name="Id">Delete data</param>
        /// <returns>delete data by ID</returns>
        [HttpDelete("{Id}")]
        public IActionResult DeleteQuntity(int Id)
        {
            try
            {
                var result = BusinessLayer.DeleteQuntity(Id);
                //if result is not equal to zero then details Deleted sucessfully
                if (!result.Equals(null))
                {
                    var Success = "True";
                    var Message = "Data deleted Sucessfully";
                    return this.Ok(new { Success, Message, Data = Id });
                }
                else                                           //Data is not deleted 
                {
                    var Success = "False";
                    var Message = "Data is not deleted Sucessfully";
                    return this.BadRequest(new { Success, Message, Data = Id });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        ///  API for get all emplyee details
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<Quantity>> GetAllQuantity()
        {
            try
            {
                var result = BusinessLayer.GetAllQuantity();
                //if result is not equal to zero then details found
                if (!result.Equals(null))
                {
                    var Success = "True";
                    var Message = "Conversion Data found ";
                    return this.Ok(new { Success, Message, Data = result });
                }
                else                                           //Data is not found
                {
                    var Success = "False";
                    var Message = "Conversion Data is not found";
                    return this.BadRequest(new { Success, Message, Data = result });
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        ///  API for get specific Quantity details
        /// </summary>
        /// <param name="Id">Update data</param>
        /// <returns> data by ID </returns>
        [HttpGet("{Id}")]
        public IActionResult GetspecificQuantity(int Id)
        {
            try
            {
                var result = BusinessLayer.GetspecificQuantity(Id);
                //if result is not equal to zero then details found
                if (!result.Equals(null))
                {
                    var Success = "True";
                    var Message = "Conversion Data found ";
                    return this.Ok(new { Success, Message, Data = result });
                }
                else                                           //Data is not found
                {
                    var Success = "False";
                    var Message = "Conversion Data is not found";
                    return this.BadRequest(new { Success, Message, Data = result });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method to Add Conversion Detail
        /// </summary>
        /// <param name="Info"></param>
        /// <returns> add conversion in database </returns>
        [HttpPost]
        [Route("comparison")]
        public IActionResult AddComparison([FromBody]Comparision Info)
        {
            try
            {
                var result = BusinessLayer.AddComparison(Info);
                if (result == null)
                {
                    return BadRequest(new { Success = false, message = CustomException.ExceptionType.INPUT_NULL });
                }
                //if entry is not equal to null
                if (!result.Equals(null))
                {
                    var Success = "True";
                    var Message = "New Entry Added Sucessfully";
                    return this.Ok(new { Success, Message, data = Info });
                }
                else                                              //Entry is not added
                {
                    var Success = "False";
                    var Message = "New Entry is not Added";
                    return this.BadRequest(new { Success, Message, data = Info });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}