using BusinessLayer.Interface;
using CommanLayer.CustomException;
using CommanLayer.Models;
using RepositoryLayer.Interface;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;
using static CommanLayer.UnitOptionType;

namespace BusinessLayer.Services
{
    public class QuantityMeasurementBL: IQuantityMeasurementBL
    {
        private IQuantityMeasurementRL _QuantityMeasurementRL;
        public QuantityMeasurementBL(IQuantityMeasurementRL QuantityMeasurementRL)
        {
            _QuantityMeasurementRL = QuantityMeasurementRL;
        }
        public Quantity Convert(Quantity quantity)
        {
            try
            {
                quantity.Result = Calculate(quantity);
                if (quantity.Result > 0)
                {
                    return _QuantityMeasurementRL.Add(quantity);
                }
                return quantity;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }





        /// <summary>
        /// Function To Perform Calculations For Conversion.
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double Calculate(Quantity quantity)
        {
            try
            {
                string operation = quantity.OptionType;
                double value = quantity.Value;
                double result = quantity.Result;
                const double INCH_FEET_CONSTANT = 12;
                const double INCH_YARD_CONSTANT = 36;
                const double FEET_YARD_CONSTANT = 3;
                const double WEIGHT_CONSTANT = 1000;
                const double GALLON_TO_LITRE_CONSTANT = 3.78;
                const double GALLON_TO_ML_CONSTANT = 3785.41;
                const double VOLUME_CONSTANT = 1000;

                if (operation == OptionType.InchToFeet.ToString())
                {
                    result = value / INCH_FEET_CONSTANT;
                }
                else if (operation == OptionType.InchToYard.ToString())
                {
                    result = value / INCH_YARD_CONSTANT;
                }
                else if (operation == OptionType.FeetToInch.ToString())
                {
                    result = value * INCH_FEET_CONSTANT;
                }
                else if (operation == OptionType.FeetToYard.ToString())
                {
                    result = value / FEET_YARD_CONSTANT;
                }
                else if (operation == OptionType.YardToInch.ToString())
                {
                    result = value * INCH_YARD_CONSTANT;
                }
                else if (operation == OptionType.YardToFeet.ToString())
                {
                    result = value * FEET_YARD_CONSTANT;
                }
                else if (operation == OptionType.GramToKg.ToString())
                {
                    result = value / WEIGHT_CONSTANT;
                }
                else if (operation == OptionType.GramToTone.ToString())
                {
                    result = value / (WEIGHT_CONSTANT * WEIGHT_CONSTANT);
                }
                else if (operation == OptionType.KgToGram.ToString())
                {
                    result = value * WEIGHT_CONSTANT;
                }
                else if (operation == OptionType.KgToTone.ToString())
                {
                    result = value / WEIGHT_CONSTANT;
                }
                else if (operation == OptionType.ToneToGram.ToString())
                {
                    result = value * (WEIGHT_CONSTANT * WEIGHT_CONSTANT);
                }
                else if (operation == OptionType.ToneToKg.ToString())
                {
                    result = value * WEIGHT_CONSTANT;
                }
                else if (operation == OptionType.MLToLiter.ToString())
                {
                    result = value / VOLUME_CONSTANT;
                }
                else if (operation == OptionType.LiterToML.ToString())
                {
                    result = value * VOLUME_CONSTANT;
                }
                else if (operation == OptionType.MLToGallon.ToString())
                {
                    result = value / GALLON_TO_ML_CONSTANT;
                }
                else if (operation == OptionType.LiterToGallon.ToString())
                {
                    result = value / GALLON_TO_LITRE_CONSTANT;
                }
                else if (operation == OptionType.GallonToML.ToString())
                {
                    result = value * GALLON_TO_ML_CONSTANT;
                }
                else if (operation == OptionType.GallonToLiter.ToString())
                {
                    result = value * GALLON_TO_LITRE_CONSTANT;
                }
                else if (operation == OptionType.FToC.ToString())
                {
                    result = (value - 32) * 5 / 9;
                }
                else if (operation == OptionType.CToF.ToString())
                {
                    result = (value * 9 / 5) + 32;
                }
                return Math.Round(result, 2);
            }
            catch (CustomException)
            {
                throw new CustomException(CustomException.ExceptionType.TYPE_NOT_MATCH);
            }
        }
    }
}
