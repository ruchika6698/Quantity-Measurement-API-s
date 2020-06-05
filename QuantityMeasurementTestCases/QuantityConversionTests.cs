using BusinessLayer.Interface;
using BusinessLayer.Services;
using CommanLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QuantityMeasurementAPI.Controllers;
using RepositoryLayer.ApplicationDatabase;
using RepositoryLayer.Interface;
using RepositoryLayer.Services;
using System;
using Xunit;

namespace QuantityMeasurementTestCases
{
    public class QuantityConversionTests
    {
        readonly QuantityMeasurementBL _businessLayer;
        readonly QuantityMeasurementRL _reposLayer;
        private readonly IConfiguration _configuration;

        public static DbContextOptions<AppDbContext> Quantities { get; }

        /// <summary>
        ///Connection String to connect to Database
        /// </summary>
        public static string sqlconnectionstring = "Data Source=BOSS-PC;Initial Catalog=QuantityMeasurement;Integrated Security=True";

        static QuantityConversionTests()
        {
            Quantities = new DbContextOptionsBuilder<AppDbContext>().UseSqlServer(sqlconnectionstring).Options;
        }
        public QuantityConversionTests()
        {
            var context = new AppDbContext(Quantities);
            _reposLayer = new QuantityMeasurementRL(context);
            _businessLayer = new QuantityMeasurementBL(_reposLayer);
        }
        
        /// <summary>
        ///Test Case for Length Unit Inch to Yard Conversion
        /// </summary>
        [Fact]
        public void GivenLengthUnitData_WhenQuantityOptionType_PassResult_Ok()
        {
            try
            {
                var controller = new MeasurementController(_businessLayer, _configuration);
                var result = new Quantity
                {
                    OptionType = "InchToYard",
                    Value = 24
                };
                var okResult = controller.Convert(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        ///Test Case for Weight Unit gram to KG Conversion
        /// </summary>
        [Fact]
        public void GivenWeightUnit_WhenQuantityOptionType_PassResult_Ok()
        {
            try
            {
                var controller = new MeasurementController(_businessLayer, _configuration);
                var result = new Quantity
                {
                    OptionType = "GramToKg",
                    Value = 20000
                };
                var okResult = controller.Convert(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        ///Test Case for Weight Unit Mililiter to Liter Conversion
        /// </summary>
        [Fact]
        public void GivenVolumeUnit_WhenQuantityOptionType_PassResult_Ok()
        {
            try
            {
                var controller = new MeasurementController(_businessLayer, _configuration);
                var result = new Quantity
                {
                    OptionType = "MLToLiter",
                    Value = 20000
                };
                var okResult = controller.Convert(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        ///Test Case for Degree Unit Farenhit to Celcius Conversion
        /// </summary>
        [Fact]
        public void GivenDegreeUnit_WhenQuantityOptionType_PassResult_Ok()
        {
            try
            {
                var controller = new MeasurementController(_businessLayer, _configuration);
                var result = new Quantity
                {
                    OptionType = "FToC",
                    Value = 100
                };
                var okResult = controller.Convert(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        ///Test Case for Two Length Units Comparison
        /// </summary>
        [Fact]
        public void GivenLengthUnitData_WhenComparison_PassResult()
        {
            try
            {
                var controller = new MeasurementController(_businessLayer, _configuration);
                var result = new Comparision
                {
                    Value_One = 12,
                    Value_One_Unit = "Feet",
                    Value_Two = 6,
                    Value_Two_Unit = "Yard"
                };
                var okResult = controller.AddComparison(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        ///Test Case for Two Degree Units Comparison
        /// </summary>
        [Fact]
        public void GivenDegreeUnitData_WhenComparison_PassResultEqual()
        {
            try
            {
                var controller = new MeasurementController(_businessLayer, _configuration);
                var result = new Comparision
                {
                    Value_One = 0,
                    Value_One_Unit = "C",
                    Value_Two = 0,
                    Value_Two_Unit = "C"
                };
                var okResult = controller.AddComparison(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        ///Test Case for Two Degree Units Comparison
        /// </summary>
        [Fact]
        public void GivenVolumeUnit_WhentwoDifferentUnit_ComparisonandPassResultEqual()
        {
            try
            {
                var controller = new MeasurementController(_businessLayer, _configuration);
                var result = new Comparision
                {
                    Value_One = 20,
                    Value_One_Unit = "Liter",
                    Value_Two = 4.9625,
                    Value_Two_Unit = "Gallon"
                };
                var okResult = controller.AddComparison(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        ///Test Case for Two Degree Units Comparison
        /// </summary>
        [Fact]
        public void GivenWeightUnit_WhentwoDifferentUnit_ComparisonandPassResult()
        {
            try
            {
                var controller = new MeasurementController(_businessLayer, _configuration);
                var result = new Comparision
                {
                    Value_One = 100,
                    Value_One_Unit = "Kg",
                    Value_Two = 10,
                    Value_Two_Unit = "Tone"
                };
                var okResult = controller.AddComparison(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
