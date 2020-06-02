using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommanLayer
{
    public class UnitOptionType
    {
        public enum OprationType
        {
            // Length Units
            InchToFeet, InchToYard,
            FeetToInch, FeetToYard,
            YardToInch, YardToFeet,
            CmToInch, InchToCm,
            CmToFeet, FeetToCm,
            CmToYard, YardToCm,
            // Volume Units
            MLToLiter, MLToGallon,
            LiterToML, LiterToGallon,
            GallonToML, GallonToLiter,
            //Weight Units
            GramToKg, GramToTone,
            KgToGram, KgToTone,
            ToneToGram, ToneToKg,
            // TempratureMeasurements
            CToF, FToC
        }
        // All units
        public enum Unit
        {
            // length units Id=^1
            Cm , Inch, Feet , Yard ,
            // liter units Id=^2
            Ml, Liter , Gallon,
            // weight units Id=^3
            Gram, Kg, Tone,
            // temperature units Id:^4
            C , F
        }
    }
}
