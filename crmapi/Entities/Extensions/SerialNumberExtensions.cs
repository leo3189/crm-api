using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Extensions
{
    public static class SerialNumberExtensions
    {
        public static void Map(this SerialNumber dbSerialNumber, SerialNumber serialNumber)
        {
            dbSerialNumber.Id = serialNumber.Id;
            dbSerialNumber.Serial_Number = serialNumber.Serial_Number;
            dbSerialNumber.ImportDate = serialNumber.ImportDate;
            dbSerialNumber.ExportDate = serialNumber.ExportDate;
            //dbSerialNumber.ItemId = serialNumber.ItemId;
            dbSerialNumber.CustomerId = serialNumber.CustomerId;
        }
    }
}
