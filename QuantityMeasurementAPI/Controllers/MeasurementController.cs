using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using CommanLayer;
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

        
    }
}