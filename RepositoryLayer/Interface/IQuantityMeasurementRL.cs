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

        /// <summary>
        ///  API for Delete data
        /// </summary>
        /// <param name="Id">Delete data</param>
        /// <returns>delete data by ID</returns>
        Quantity DeleteQuntity(int Id);

        /// <summary>
        ///  API for get all emplyee details
        /// </summary>
        IEnumerable<Quantity> GetAllQuantity();

        /// <summary>
        ///  API for get specific Quantity details
        /// </summary>
        /// <param name="Id">Update data</param>
        /// <returns> data by ID </returns>
        Quantity GetspecificQuantity(int Id);

        /// <summary>
        /// Method to Add Conversion Detail
        /// </summary>
        /// <param name="comparison"></param>
        /// <returns> add conversion in database </returns>
        Comparision AddComparison(Comparision comparison);

    }
}
