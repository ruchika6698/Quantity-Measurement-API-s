using CommanLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IQuantityMeasurementBL
    {
        /// <summary>
        /// Method to Perform Conversion.
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns>Conversion of units</returns>
        Quantity Convert(Quantity quantity);
        double Calculate(Quantity quantity);
        Quantity DeleteQuntity(int Id);
        IEnumerable<Quantity> GetAllQuantity();

    }
}
