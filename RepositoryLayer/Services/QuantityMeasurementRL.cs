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
        /// <summary>
        /// Method to Add Conversion Detail to Database.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Conversion result</returns>
        public Quantity DeleteQuntity(int Id)
        {
            try
            {
                Quantity quantity = dBContext.Quantities.Find(Id);
                if(quantity != null)
                {
                    dBContext.Quantities.Remove(quantity);
                    dBContext.SaveChanges();
                }
                return quantity;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method To Get All Convserion Details.
        /// </summary>
        public IEnumerable<Quantity> GetAllQuantity()
        {
            try
            {
                return dBContext.Quantities;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
         