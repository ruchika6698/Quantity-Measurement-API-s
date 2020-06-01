using CommanLayer.Models;
using RepositoryLayer.ApplicationDatabase;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Services
{
    public class QuantityMeasurementRL : IQuantityMeasurementRL
    {
        //DBContext Refernce.
        private AppDbContext dBContext;

        /// <summary>
        /// Parameter Constructor For Seting DbContext Reference by DI.
        /// </summary>
        /// <param name="dBContext"></param>
        public QuantityMeasurementRL(AppDbContext dBContext)
        {
            this.dBContext = dBContext;
        }
        /// <summary>
        /// Method to Add Conversion Detail to Database.
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns>Conversion result</returns>
        public Quantity Add(Quantity quantity)
        {
            try
            {
                dBContext.Quantities.Add(quantity);
                dBContext.SaveChanges();
                return quantity;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
         