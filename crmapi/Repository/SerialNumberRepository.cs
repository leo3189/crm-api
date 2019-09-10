using Contracts;
using Entities;
using Entities.Extensions;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class SerialNumberRepository : RepositoryBase<SerialNumber>, ISerialNumberRepository
    {
        public SerialNumberRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {

        }

        public void CreateSerialNumber(SerialNumber serialNumber)
        {
            serialNumber.Id = Guid.NewGuid();
            Create(serialNumber);
        }

        public void DeleteSerialNumber(SerialNumber serialNumber)
        {
            Delete(serialNumber);
        }

        public IEnumerable<SerialNumber> GetAllSerialNumbers()
        {
            return FindAll()
                    .ToList();
        }

        public SerialNumber GetSerialNumberById(Guid serialNumberId)
        {
            return FindByCondition(serialNumber => serialNumber.Id.Equals(serialNumberId))
                    .DefaultIfEmpty(new SerialNumber())
                    .FirstOrDefault();
        }

        //public IEnumerable<SerialNumber> SerialNumbersByItem(Guid itemId)
        //{
        //    return FindByCondition(serialNumber => serialNumber.ItemId.Equals(itemId)).ToList();
        //}

        public void UpdateSerialNumber(SerialNumber dbSerialNumber, SerialNumber serialNumber)
        {
            dbSerialNumber.Map(serialNumber);
            Update(serialNumber);
        }
    }
}
