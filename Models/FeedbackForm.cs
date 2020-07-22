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
        public string Name { get; set; }
        [Required]
        public string Computer { get; set; }
        [Required]
        public int Rating { get; set; }
        [StringLength(500)]
        public string Comment { get; set; }
    }
}
