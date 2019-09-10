using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private ICustomerRepository _customer;
        private IItemRepository _item;
        private IItemCategoryRepository _itemCategory;
        private ISerialNumberRepository _serialNumber;
        private IInventoryRepository _inventory;

        public ICustomerRepository Customer
        {
            get
            {
                if (_customer == null)
                {
                    _customer = new CustomerRepository(_repoContext);
                }

                return _customer;
            }
        }

        public IItemRepository Item
        {
            get
            {
                if (_item == null)
                {
                    _item = new ItemRepository(_repoContext);
                }

                return _item;
            }
        }

        public IItemCategoryRepository ItemCategory
        {
            get
            {
                if (_itemCategory == null)
                {
                    _itemCategory = new ItemCategoryRepository(_repoContext);
                }

                return _itemCategory;
            }
        }

        public ISerialNumberRepository SerialNumber
        {
            get
            {
                if (_serialNumber == null)
                {
                    _serialNumber = new SerialNumberRepository(_repoContext);
                }

                return _serialNumber;
            }
        }

        public IInventoryRepository Inventory
        {
            get
            {
                if (_inventory == null)
                {
                    _inventory = new InventoryRepository(_repoContext);
                }

                return _inventory;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
