using Contracts;
using Entities;
using Entities.ExtendedModels;
using Entities.Extensions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class ItemRepository : RepositoryBase<Item>, IItemRepository
    {
        public ItemRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Item> GetAllItems()
        {
            return FindAll()
                .OrderBy(item => item.Name)
                .ToList();
        }

        public Item GetItemById(Guid ItemId)
        {
            return FindByCondition(item => item.Id.Equals(ItemId))
                .DefaultIfEmpty(new Item())
                .FirstOrDefault();
        }
        public ItemExtended GetItemWithInventoryItem(Guid itemId)
        {
            return new ItemExtended(GetItemById(itemId))
            {
                Inventory = RepositoryContext.Inventory
                    .Where(a => a.ItemId == itemId)
                    .Include(a => a.SerialNumbers)
            };
        }

        public void CreateItem(Item item)
        {
            item.Id = Guid.NewGuid();
            Create(item);
        }

        public void DeleteItem(Item item)
        {
            Delete(item);
        }

        public void UpdateItem(Item dbItem, Item item)
        {
            dbItem.Map(item);
            Update(item);
        }

        public IEnumerable<Item> ItemsByItemCategory(Guid categoryId)
        {
            return FindByCondition(a => a.CategoryId.Equals(categoryId)).ToList();
        }

    }
}
