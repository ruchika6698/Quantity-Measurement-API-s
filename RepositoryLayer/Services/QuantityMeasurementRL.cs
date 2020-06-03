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
        /// Parameter Constructor For Seting DbContext Reference.
        /// </summary>
        /// <param name="dBContext"></param>
        public QuantityMeasurementRL(AppDbContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public QuantityMeasurementRL()
        {
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
                //add Data in database
                dBContext.Quantities.Add(quantity);
                //saves all changes in database
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
                    //Remove Data in database
                    dBContext.Quantities.Remove(quantity);
                    //saves all changes in database
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
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Function to get Specific Conversion Detail.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Quantity GetspecificQuantity(int Id)
        {
            try
            {
                //Find data from database by ID
                Quantity quantity = dBContext.Quantities.Find(Id);
                return quantity;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Function To Add Comparison Detail to Database.
        /// </summary>
        /// <param name="comparison"></param>
        /// <returns></returns>
        public Comparision AddComparison(Comparision comparison)
        {
            try
            {
                //send the data to database and add
                dBContext.Comparisions.Add(comparison);
                //saves all changes in database
                dBContext.SaveChanges();
                return comparison;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
         