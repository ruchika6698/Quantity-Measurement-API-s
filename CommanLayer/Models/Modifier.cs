using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommanLayer.Models
{
    public class Modifier
    {
        //properties
        [Key]
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z][a-zA-Z]*$")]
        public string OptionType { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [RegularExpression(@"^\d+(\.\d{1,2})?")]
        public double Value { get; set; }
        public DateTime DateOnCreation { get; set; } = DateTime.Today;
    }
}
