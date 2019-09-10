using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("item")]
    public class Item : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Item name is required")]
        public string Name { get; set; }
        public string PartNumber { get; set; }
        public decimal Cost { get; set; }
        public decimal SalesPrice { get; set; }
        public DateTime LastUpdated { get; set; }
        public Guid CategoryId { get; set; }
        public bool IsInventory { get; set; }

        public IEnumerable<Inventory> Inventory { get; set; }
    }
}
