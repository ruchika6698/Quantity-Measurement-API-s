﻿using CommanLayer.Models;
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
        Quantity GetspecificQuantity(int Id);
        Comparision AddComparison(Comparision comparison);
        string SetBaseUnit(Quantity quantity);
        Comparision ConvertToBaseUnit(Comparision comparison);
        string SetOperationType(string Unit_Value);
        string CompareConversion(Comparision comparison);
    }
}
