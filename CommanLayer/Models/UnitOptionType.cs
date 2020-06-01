using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommanLayer
{
    public class UnitOptionType
    {
        public enum OptionType
        {
            // Length Units
            InchToFeet, InchToYard,
            FeetToInch, FeetToYard,
            YardToInch, YardToFeet,
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
            Cm = 1, Inch = 2, Feet = 3, Yard = 4,
            // liter units Id=^2
            Ml = 11, Liter = 12, Gallon = 13,
            // weight units Id=^3
            Gram = 21, Kg = 22, Tone = 23,
            // temperature units Id:^4
            C = 31, F = 32
        }
    }
}
