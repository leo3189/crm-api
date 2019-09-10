using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Extensions
{
    public static class InventoryExtensions
    {
        public static void Map(this Inventory dbInventory, Inventory inventory)
        {
            dbInventory.InventoryId = inventory.InventoryId;
            dbInventory.InStock = inventory.InStock;
            dbInventory.ItemId = inventory.ItemId;
        }
    }
}
