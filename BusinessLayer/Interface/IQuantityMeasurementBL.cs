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

        /// <summary>
        /// Method to  Calculate Conversion.
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns> result of Conversion</returns>
        double Calculate(Quantity quantity);

        /// <summary>
        ///  API for Delete data
        /// </summary>
        /// <param name="Id">Delete data</param>
        /// <returns>delete data by ID</returns>
        IEnumerable<Quantity> DeleteQuntity(int Id);

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

        /// <summary>
        /// Function For Setting Base Unit.
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns>set the base unit</returns>
        string SetBaseUnit(Quantity quantity);

        /// <summary>
        /// Function For Converting To Base Unit.
        /// </summary>
        /// <param name="comparison"></param>
        /// <returns> convert to base unit </returns>
        Comparision ConvertToBaseUnit(Comparision comparison);

        /// <summary>
        /// Functin Fr Setting peratin type For Base Unit Conversion.
        /// </summary>
        /// <param name="Unit_Value"></param>
        string SetOperationType(string Unit_Value);

        /// <summary>
        /// Method To Perform Comparison.
        /// </summary>
        /// <param name="comparison"></param>
        /// <returns> Comparison result </returns>
        string CompareConversion(Comparision comparison);
    }
}
