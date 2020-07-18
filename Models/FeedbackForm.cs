using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseC.Models
{
    public class FeedbackForm
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Computer Computer { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}
