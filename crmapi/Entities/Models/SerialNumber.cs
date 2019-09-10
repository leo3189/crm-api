using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("serial_number")]
    public class SerialNumber
    {
        [Key]
        public Guid Id { get; set; }
        [Column("SerialNumber")]
        public string Serial_Number { get; set; }
        public DateTime ImportDate { get; set; }
        public DateTime ExportDate { get; set; }
        //public Guid ItemId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid InventoryId { get; set; }
    }
}
