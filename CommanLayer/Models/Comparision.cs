using System;
using System.Collections.Generic;
using System.Text;

namespace CommanLayer.Models
{
    public class Comparision
    {
        public double ValueOne { get; set; }
        public UnitOptionType.Unit FirstUnit { get; set; }
        public double ValueTwo { get; set; }
        public UnitOptionType.Unit SecondUnit { get; set; }

        /// <summary>
        /// Constructor to initlize properties
        /// </summary>
        /// <param name="in_valueOne"></param>
        /// <param name="firstvalue"></param>
        /// <param name="in_valueTwo"></param>
        /// <param name="secondvalue"></param>
        public Comparision(double in_valueOne, UnitOptionType.Unit firstvalue, double in_valueTwo, UnitOptionType.Unit secondvalue)
        {
            this.ValueOne = in_valueOne;
            this.ValueTwo = in_valueTwo;
            this.FirstUnit = firstvalue;
            this.SecondUnit = secondvalue;
        }
        /// <summary>
        /// Empty constructor to initialize empty object
        /// </summary>
        public Comparision()
        {

        }
    }
}
