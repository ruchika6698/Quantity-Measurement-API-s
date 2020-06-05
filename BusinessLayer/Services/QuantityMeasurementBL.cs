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
        /// <summary>
        /// Method to Add Conversion Detail
        /// </summary>
        /// <param name="quantity">value from quantity model</param>
        /// <returns>Return result of conversion</returns>
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
        ///  API for Delete data
        /// </summary>
        /// <param name="Id">Delete data</param>
        /// <returns></returns>
        public Quantity DeleteQuntity(int Id)
        {
            try
            {
                return _QuantityMeasurementRL.DeleteQuntity(Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        ///  API for get all details
        /// </summary>
        public IEnumerable<Quantity> GetAllQuantity()
        {
            try
            {
                return _QuantityMeasurementRL.GetAllQuantity();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        ///  API for get specific Quantity details
        /// </summary>
        /// <param name="Id"> get specific Entry</param>
        /// <returns>Return Specific Entry</returns>
        public Quantity GetspecificQuantity(int Id)
        {
            try
            {
                return _QuantityMeasurementRL.GetspecificQuantity(Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Function To Add Comparison.
        /// </summary>
        /// <param name="comparison"></param>
        /// <returns></returns>
        public Comparision AddComparison(Comparision comparison)
        {
            try
            {
                comparison.Result = CompareConversion(comparison);
                if (comparison.Result != null)
                {
                    return _QuantityMeasurementRL.AddComparison(comparison);
                }
                return comparison;
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
        /// <returns> Conversion result </returns>
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
                const double CM_INCH_CONSTANT = 2.5;
                const double CM_FEET_CONSTANT = 30.48;
                const double CM_YARD_CONSTANT = 91.44;
                const double WEIGHT_CONSTANT = 1000;
                const double GALLON_TO_LITRE_CONSTANT = 3.78;
                const double GALLON_TO_ML_CONSTANT = 3785.41;
                const double VOLUME_CONSTANT = 1000;

                if (operation == OprationType.InchToFeet.ToString())
                {
                    result = value / INCH_FEET_CONSTANT;
                }
                else if (operation == OprationType.InchToYard.ToString())
                {
                    result = value / INCH_YARD_CONSTANT;
                }
                else if (operation == OprationType.FeetToInch.ToString())
                {
                    result = value * INCH_FEET_CONSTANT;
                }
                else if (operation == OprationType.FeetToYard.ToString())
                {
                    result = value / FEET_YARD_CONSTANT;
                }
                else if (operation == OprationType.YardToInch.ToString())
                {
                    result = value * INCH_YARD_CONSTANT;
                }
                else if (operation == OprationType.YardToFeet.ToString())
                {
                    result = value * FEET_YARD_CONSTANT;
                }
                else if (operation == OprationType.CmToInch.ToString())
                {
                    result = value / CM_INCH_CONSTANT;
                }
                else if (operation == OprationType.InchToCm.ToString())
                {
                    result = value * CM_INCH_CONSTANT;
                }
                else if (operation == OprationType.CmToFeet.ToString())
                {
                    result = value / CM_FEET_CONSTANT;
                }
                else if (operation == OprationType.FeetToCm.ToString())
                {
                    result = value * CM_FEET_CONSTANT;
                }
                else if (operation == OprationType.CmToYard.ToString())
                {
                    result = value / CM_YARD_CONSTANT;
                }
                else if (operation == OprationType.YardToCm.ToString())
                {
                    result = value * CM_YARD_CONSTANT;
                }
                else if (operation == OprationType.GramToKg.ToString())
                {
                    result = value / WEIGHT_CONSTANT;
                }
                else if (operation == OprationType.GramToTone.ToString())
                {
                    result = value / (WEIGHT_CONSTANT * WEIGHT_CONSTANT);
                }
                else if (operation == OprationType.KgToGram.ToString())
                {
                    result = value * WEIGHT_CONSTANT;
                }
                else if (operation == OprationType.KgToTone.ToString())
                {
                    result = value / WEIGHT_CONSTANT;
                }
                else if (operation == OprationType.ToneToGram.ToString())
                {
                    result = value * (WEIGHT_CONSTANT * WEIGHT_CONSTANT);
                }
                else if (operation == OprationType.ToneToKg.ToString())
                {
                    result = value * WEIGHT_CONSTANT;
                }
                else if (operation == OprationType.MLToLiter.ToString())
                {
                    result = value / VOLUME_CONSTANT;
                }
                else if (operation == OprationType.LiterToML.ToString())
                {
                    result = value * VOLUME_CONSTANT;
                }
                else if (operation == OprationType.MLToGallon.ToString())
                {
                    result = value / GALLON_TO_ML_CONSTANT;
                }
                else if (operation == OprationType.LiterToGallon.ToString())
                {
                    result = value / GALLON_TO_LITRE_CONSTANT;
                }
                else if (operation == OprationType.GallonToML.ToString())
                {
                    result = value * GALLON_TO_ML_CONSTANT;
                }
                else if (operation == OprationType.GallonToLiter.ToString())
                {
                    result = value * GALLON_TO_LITRE_CONSTANT;
                }
                else if (operation == OprationType.FToC.ToString())
                {
                    result = (value - 32) * 5 / 9;
                }
                else if (operation == OprationType.CToF.ToString())
                {
                    result = (value * 9 / 5) + 32;
                }
                else if (operation == OprationType.CToK.ToString())
                {
                    result = (value + 273.15);
                }
                else if (operation == OprationType.FToK.ToString())
                {
                    result = ((value - 32) * 5 / 9) + 273.15;
                }
                else if (operation == OprationType.KToC.ToString())
                {
                    result = (value - 273.15);
                }
                else if (operation == OprationType.KToF.ToString())
                {
                    result = ((value - 32) * 9 / 5) + 273.15;
                }
                return Math.Round(result, 2);
            }
            catch (CustomException)
            {
                throw new CustomException(CustomException.ExceptionType.TYPE_NOT_MATCH);
            }
        }

        /// <summary>
        /// Method To Perform Comparison.
        /// </summary>
        /// <param name="comparison"></param>
        /// <returns> Comparison result </returns>
        public string CompareConversion(Comparision comparison)
        {
            try
            {
                Comparision comparison1 = new Comparision();
                comparison1.Value_One = comparison.Value_One;
                comparison1.Value_One_Unit = comparison.Value_One_Unit;
                comparison1.Value_Two = comparison.Value_Two;
                comparison1.Value_Two_Unit = comparison.Value_Two_Unit;
                comparison1 = ConvertToBaseUnit(comparison1);

                string result = "";

                if (comparison1.Value_One_Unit == Unit.Inch.ToString() && comparison1.Value_Two_Unit == Unit.Inch.ToString()
                    || comparison1.Value_One_Unit == Unit.Gram.ToString() && comparison1.Value_Two_Unit == Unit.Gram.ToString()
                    || comparison1.Value_One_Unit == Unit.Ml.ToString() && comparison1.Value_Two_Unit == Unit.Ml.ToString()
                    || comparison1.Value_One_Unit == Unit.F.ToString() && comparison1.Value_Two_Unit == Unit.F.ToString())
                {
                    if (comparison1.Value_One == comparison1.Value_Two)
                    {
                        result = "Equal";
                    }
                    else if (comparison1.Value_One > comparison1.Value_Two)
                    {
                        result = $"{comparison.Value_One} Is Greater Than {comparison.Value_Two}";
                    }
                    else if (comparison1.Value_One < comparison1.Value_Two)
                    {
                        result = $"{comparison.Value_One} Is Less Than {comparison.Value_Two}";
                    }
                }
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        /// <summary>
        /// Functin Fr Setting peratin type For Base Unit Conversion.
        /// </summary>
        /// <param name="Unit_Value"></param>
        public string SetOperationType(string Unit_Value)
        {
            try
            {
                string operationType = "";
                if (Unit_Value == Unit.Feet.ToString())
                {
                    operationType = "FeetToInch";
                }
                else if (Unit_Value == Unit.Yard.ToString())
                {
                    operationType = "YardToInch";
                }
                else if (Unit_Value == Unit.Cm.ToString())
                {
                    operationType = "CmToInch";
                }
                else if (Unit_Value == Unit.Kg.ToString())
                {
                    operationType = "KgToGram";
                }
                else if (Unit_Value == Unit.Tone.ToString())
                {
                    operationType = "ToneToGram";
                }
                else if (Unit_Value == Unit.Liter.ToString())
                {
                    operationType = "LiterToML";
                }
                else if (Unit_Value == Unit.Gallon.ToString())
                {
                    operationType = "GallonToML";
                }
                else if (Unit_Value == Unit.C.ToString())
                {
                    operationType = "CToF";
                }
                return operationType;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Function For Converting To Base Unit.
        /// </summary>
        /// <param name="comparison"></param>
        /// <returns> convert to base unit </returns>
        public Comparision ConvertToBaseUnit(Comparision comparison)
        {
            try
            {
                //Checking If Data Is In Base Unit.
                if (comparison.Value_One_Unit == Unit.Inch.ToString() && comparison.Value_Two_Unit == Unit.Inch.ToString()
                    || comparison.Value_One_Unit == Unit.Gram.ToString() && comparison.Value_Two_Unit == Unit.Gram.ToString()
                    || comparison.Value_One_Unit == Unit.Ml.ToString() && comparison.Value_Two_Unit == Unit.Ml.ToString()
                    || comparison.Value_One_Unit == Unit.F.ToString() && comparison.Value_Two_Unit == Unit.F.ToString())
                {
                    return comparison;
                }

                //Creating QuantityModel Instances For Base Unit Conversions.
                Quantity quantityOne = new Quantity();
                Quantity quantityTwo = new Quantity();
                quantityOne.Value = comparison.Value_One;
                quantityTwo.Value = comparison.Value_Two;

                //Setting Operation Type.
                quantityOne.OptionType = SetOperationType(comparison.Value_One_Unit);
                quantityTwo.OptionType = SetOperationType(comparison.Value_Two_Unit);

                //If Both Quantity Instance Unit Are Not Base Units Then Perform Conversion.
                if (quantityOne.OptionType != "BaseUnit" && quantityTwo.OptionType != "BaseUnit")
                {
                    quantityOne.Result = Calculate(quantityOne);
                    quantityTwo.Result = Calculate(quantityTwo);

                    comparison.Value_One = quantityOne.Result;
                    comparison.Value_Two = quantityTwo.Result;

                    comparison.Value_One_Unit = SetBaseUnit(quantityOne);
                    comparison.Value_Two_Unit = SetBaseUnit(quantityTwo);
                }
                else if (quantityOne.OptionType == "BaseUnit" && quantityTwo.OptionType != "BaseUnit")
                {
                    quantityTwo.Result = Calculate(quantityTwo);
                    comparison.Value_Two = quantityTwo.Result;
                    comparison.Value_Two_Unit = SetBaseUnit(quantityTwo);
                }
                else if (quantityOne.OptionType != "BaseUnit" && quantityTwo.OptionType == "BaseUnit")
                {
                    quantityOne.Result = Calculate(quantityOne);
                    comparison.Value_One = quantityOne.Result;
                    comparison.Value_One_Unit = SetBaseUnit(quantityOne);
                }
                return comparison;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Function For Setting Base Unit.
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns>set the base unit</returns>
        public string SetBaseUnit(Quantity quantity)
        {
            try
            {
                if (quantity.OptionType == OprationType.FeetToInch.ToString()
                    || quantity.OptionType == OprationType.YardToInch.ToString() || quantity.OptionType == OprationType.CmToInch.ToString())
                {
                    return "Inch";
                }
                else if (quantity.OptionType == OprationType.KgToGram.ToString() || quantity.OptionType == OprationType.ToneToGram.ToString())
                {
                    return "Gram";
                }
                else if (quantity.OptionType == OprationType.LiterToML.ToString() || quantity.OptionType == OprationType.GallonToML.ToString())
                {
                    return "Ml";
                }
                else if (quantity.OptionType == OprationType.CToF.ToString())
                {
                    return "F";
                }
                return "Invalid";
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
