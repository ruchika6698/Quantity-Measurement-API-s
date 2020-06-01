using CommanLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IQuantityMeasurementRL
    {
        /// <summary>
        /// Method to Perform Conversion.
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns>Conversion of units</returns>
        Quantity Add(Quantity quantity);
        Quantity DeleteQuntity(int Id);
        IEnumerable<Quantity> GetAllQuantity();
        Quantity GetspecificQuantity(int Id);

    }
}
