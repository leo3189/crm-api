using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface ISerialNumberRepository : IRepositoryBase<SerialNumber>
    {
        IEnumerable<SerialNumber> GetAllSerialNumbers();
        SerialNumber GetSerialNumberById(Guid serialNumberId);
        void CreateSerialNumber(SerialNumber serialNumber);
        void UpdateSerialNumber(SerialNumber dbSerialNumber, SerialNumber serialNumber);
        void DeleteSerialNumber(SerialNumber serialNumber);
        //IEnumerable<SerialNumber> SerialNumbersByItem(Guid itemId);
    }
}
