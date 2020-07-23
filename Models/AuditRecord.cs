using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace PurchaseC.Models
{
    public class AuditRecord
    {
        [Key]
        public int Audit_ID { get; set; }

        [Display(Name = "Audit Action")]
        public string AuditActionType { get; set; }

        [Display(Name = "Performed By")]
        public string Username { get; set; }

        [Display(Name = "Date/Time Stamp")]
        [DataType(DataType.DateTime)]
        public DateTime DateTimeStamp { get; set; }

        [Display(Name = "ID")]
        public int ComputerID { get; set; }
    }
}
