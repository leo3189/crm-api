using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Extensions
{
    public static class ItemExtension
    {
        public static void Map(this Item dbItem, Item item)
        {
            dbItem.Name = item.Name;
            dbItem.PartNumber = item.PartNumber;
            dbItem.Cost = item.Cost;
            dbItem.SalesPrice = item.SalesPrice;
            dbItem.LastUpdated = item.LastUpdated;
            dbItem.IsInventory = item.IsInventory;
            dbItem.CategoryId = item.CategoryId;
        }
    }
}
