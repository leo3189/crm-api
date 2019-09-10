using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ExtendedModels
{
    public class ItemCategoryExtended
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Item> Items { get; set; }

        public ItemCategoryExtended()
        {

        }

        public ItemCategoryExtended(ItemCategory itemCat)
        {
            Id = itemCat.CategoryId;
            Name = itemCat.Name;
        }
    }
}
