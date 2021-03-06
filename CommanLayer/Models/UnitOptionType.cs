﻿using System;
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
            CToF, FToC, CToK, 
            FToK, KToC, KToF
        }
        // All units
        public enum Unit
        {
            // length units 
            Cm , Inch, Feet , Yard ,
            // liter units 
            Ml, Liter , Gallon,
            // weight units 
            Gram, Kg, Tone,
            // temperature units 
            C , F ,K
        }
    }
}
