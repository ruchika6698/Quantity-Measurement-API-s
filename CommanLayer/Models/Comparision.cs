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

        [Required]
        public double Value_One { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z][a-zA-Z]*$")]
        public string Value_One_Unit { get; set; }

        [Required]
        public double Value_Two { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z][a-zA-Z]*$")]
        public string Value_Two_Unit { get; set; }

        public string Result { get; set; }
        public DateTime DateOnCreation { get; set; } = DateTime.Today;
    }
}
