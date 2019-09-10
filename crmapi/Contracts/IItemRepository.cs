using Entities.ExtendedModels;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IItemRepository : IRepositoryBase<Item>
    {
        IEnumerable<Item> GetAllItems();
        Item GetItemById(Guid ItemId);
        void CreateItem(Item item);
        void UpdateItem(Item dbItem, Item item);
        void DeleteItem(Item item);
        IEnumerable<Item> ItemsByItemCategory(Guid categoryId);
        //ItemExtended GetItemWithSerialNumbers(Guid itemId);
        ItemExtended GetItemWithInventoryItem(Guid itemId);
    }
}
