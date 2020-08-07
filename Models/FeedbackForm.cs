using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseC.Models
{
    public class FeedbackForm
    {
        public int ID { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9""'\s-]*$", ErrorMessage = "Entered Text contain Invalid characters")]
        [Display(Name = "Name/Username")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Computer should only contain Alphabets")]
        public string Computer { get; set; }

        [Required]
        public int Rating { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9""'\s-!,.:;?']*$", ErrorMessage = "Entered Text contain Invalid characters")]
        [StringLength(500)]
        public string Comment { get; set; }
    }
}
