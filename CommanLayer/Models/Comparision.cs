using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommanLayer.Models
{
    public class Comparision
    {
        [Key]
        public int Id { get; set; }

        //value for First unit value
        [Required]
        public double Value_One { get; set; }

        //value for First unit
        [Required]
        [RegularExpression(@"^[A-Z][a-zA-Z]*$")]
        public string Value_One_Unit { get; set; }

        //value for Second unit value
        [Required]
        public double Value_Two { get; set; }

        //value for Second unit
        [Required]
        [RegularExpression(@"^[A-Z][a-zA-Z]*$")]
        public string Value_Two_Unit { get; set; }

        //result of comparison
        public string Result { get; set; }

        //date and time when result is generated
        public DateTime DateOnCreation { get; set; } = DateTime.Now;
    }
}
