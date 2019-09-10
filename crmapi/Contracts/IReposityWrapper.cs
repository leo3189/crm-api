using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        ICustomerRepository Customer { get; }

        IItemRepository Item { get; }
        
        IItemCategoryRepository ItemCategory { get; }

        ISerialNumberRepository SerialNumber { get; }

        IInventoryRepository Inventory { get; }

        void Save();
    }
}
