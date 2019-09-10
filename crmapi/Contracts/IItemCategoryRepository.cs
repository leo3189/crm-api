using Entities.ExtendedModels;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IItemCategoryRepository : IRepositoryBase<ItemCategory>
    {
        IEnumerable<ItemCategory> GetAllItemCategories();
        ItemCategory GetItemCategoryById(Guid catId);
        ItemCategoryExtended GetCategoryWithItems(Guid catId);
        void CreateItemCategory(ItemCategory itemCategory);
        void UpdateItemCategory(ItemCategory dbItemCategory, ItemCategory itemCat);
        void DeleteItemCategory(ItemCategory itemCat);
    }
}
