using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ExtendedModels
{
    public class InventoryExtended
    {
        public Guid Id { get; set; }
        public int InStock { get; set; }
        public Guid ItemId { get; set; }
        public IEnumerable<SerialNumber> SerialNumbers { get; set; }
        public InventoryExtended()
        {

        }
        public InventoryExtended(Inventory inv)
        {
            Id = inv.InventoryId;
            InStock = inv.InStock;
            ItemId = inv.ItemId;
        }
    }
}
