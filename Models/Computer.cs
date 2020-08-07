using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Microsoft.AspNetCore.Http;

namespace PurchaseC.Models
{
    public class Computer
    {
        [DisplayName("Images")]
        public string Images { get; set; }

        public int ID { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Release Date")]
        public DateTime ReleaseDate { get; set; }

        [DisplayName("Memory")]
        public string Memory { get; set; }

        [DisplayName("Processor")]
        public string Processor { get; set; }

        [DisplayName("GPU")]
        public string GPU { get; set; }

        [DisplayName("Storage Info")]
        public string Storage_Info { get; set; }

        [DisplayName("Operating System")]
        public string OS { get; set; }

        [DisplayName("PSU")]
        public string PSU { get; set; }

        [DisplayName("Motherboard")]
        public string Motherboard { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [DisplayName("Price")]
        public decimal Price { get; set; }

        
    }
}
