using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("inventory")]
    public class Inventory
    {
        [Key]
        [Column("Id")]
        public Guid InventoryId { get; set; }
        public int InStock { get; set; }
        public Guid ItemId { get; set; }

        public IEnumerable<SerialNumber> SerialNumbers { get; set; }
    }
}
