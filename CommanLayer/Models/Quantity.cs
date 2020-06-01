using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommanLayer.Models
{
    public class Quantity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //option type for different conversion
        [Required]
        [RegularExpression(@"^[A-Z][a-zA-Z]*$")]
        public string OptionType { get; set; }
        //value for input
        [Required]
        public double Value { get; set; }
        //result for conversion
        public double Result { get; set; }
        //date and time when result is generated
        public DateTime DateOnCreation { get; set; } = DateTime.Now;
    }
}
