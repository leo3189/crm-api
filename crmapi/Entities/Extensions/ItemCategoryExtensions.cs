using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Extensions
{
    public static class ItemCategoryExtensions
    {
        public static void Map(this ItemCategory dbItemCategory, ItemCategory itemCat)
        {
            dbItemCategory.Name = itemCat.Name;
        }
    }
}
