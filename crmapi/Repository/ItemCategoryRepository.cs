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
    public class ItemCategoryRepository : RepositoryBase<ItemCategory>, IItemCategoryRepository
    {
        
        public ItemCategoryRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
           
        }
        public IEnumerable<ItemCategory> GetAllItemCategories()
        {
            return FindAll()
                    .OrderBy(cat => cat.Name)
                    //.Include(cat => cat.Items)
                    .ToList();
        }

        public ItemCategoryExtended GetCategoryWithItems(Guid catId)
        {
            return new ItemCategoryExtended(GetItemCategoryById(catId))
            {
                Items = RepositoryContext.Items
                    .Where(item => item.CategoryId == catId)
                    .Include(item => item.Inventory)
                    .ThenInclude(item => item.SerialNumbers)
                    
            };
        }

        public ItemCategory GetItemCategoryById(Guid catId)
        {
            return FindByCondition(cat => cat.CategoryId.Equals(catId))
                    .DefaultIfEmpty(new ItemCategory())
                    .FirstOrDefault();
        }

        public void CreateItemCategory(ItemCategory itemCategory)
        {
            itemCategory.CategoryId = Guid.NewGuid();
            Create(itemCategory);
        }

        public void UpdateItemCategory(ItemCategory dbItemCategory, ItemCategory itemCat)
        {
            dbItemCategory.Map(itemCat);
            Update(dbItemCategory);
        }

        public void DeleteItemCategory(ItemCategory itemCat)
        {
            Delete(itemCat);
        }
    }
}
