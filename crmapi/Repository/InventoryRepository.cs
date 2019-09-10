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
    public class InventoryRepository : RepositoryBase<Inventory>, IInventoryRepository
    {
        public InventoryRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public void CreateInventory(Inventory inv)
        {
            inv.InventoryId = Guid.NewGuid();
            Create(inv);
        }

        public void DeleteInventory(Inventory inv)
        {
            Delete(inv);
        }

        public Inventory GetInventoryById(Guid invId)
        {
            return FindByCondition(a => a.InventoryId.Equals(invId))
                    .DefaultIfEmpty(new Inventory())
                    .FirstOrDefault();
        }

        public IEnumerable<Inventory> GetAllInventory()
        {
            return FindAll()
                    .Include(inv => inv.SerialNumbers)
                    .ToList();
        }

        public InventoryExtended GetInventoryWithSerialNumbers(Guid invId)
        {
            return new InventoryExtended(GetInventoryById(invId))
            {
                SerialNumbers = RepositoryContext.SerialNumbers
                    .Where(a => a.InventoryId == invId)
            };
        }

        public void UpdateInventory(Inventory dbInv, Inventory inv)
        {
            dbInv.Map(inv);
            Update(inv);
        }
    }
}
