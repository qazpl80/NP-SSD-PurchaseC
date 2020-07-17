using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace PurchaseC.Models
{
    public class Computer
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Memory { get; set; }
        public string Processor { get; set; }
        public string GPU { get; set; }
        public string Storage_Info { get; set; }
        public string OS { get; set; }
        public string PSU { get; set; }
        public string Motherboard { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}
