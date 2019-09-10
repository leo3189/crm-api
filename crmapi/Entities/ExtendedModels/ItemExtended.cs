using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ExtendedModels
{
    public class ItemExtended
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PartNumber { get; set; }
        public decimal Cost { get; set; }
        public decimal SalesPrice { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool IsInventory { get; set; }
        public Guid CategoryId { get; set; }

        //public IEnumerable<SerialNumber> SerialNumbers { get; set; }
        public IEnumerable<Inventory> Inventory { get; set; }

        public ItemExtended()
        {

        }

        public ItemExtended(Item item)
        {
            Id = item.Id;
            Name = item.Name;
            PartNumber = item.PartNumber;
            Cost = item.Cost;
            SalesPrice = item.SalesPrice;
            LastUpdated = item.LastUpdated;
            IsInventory = item.IsInventory;
            CategoryId = item.CategoryId;
        }
    }
}
