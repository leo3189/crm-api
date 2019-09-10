using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("item_category")]
    public class ItemCategory
    {
        [Key]
        [Column("Id")]
        public Guid CategoryId { get; set; }
        public string Name { get; set; }

        public List<Item> Items { get; set; }
    }
}
