using Entities.ExtendedModels;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IInventoryRepository : IRepositoryBase<Inventory>
    {
        IEnumerable<Inventory> GetAllInventory();
        Inventory GetInventoryById(Guid invId);
        void CreateInventory(Inventory inv);
        void UpdateInventory(Inventory dbInv, Inventory inv);
        void DeleteInventory(Inventory inv);
        InventoryExtended GetInventoryWithSerialNumbers(Guid invId);

    }
}
