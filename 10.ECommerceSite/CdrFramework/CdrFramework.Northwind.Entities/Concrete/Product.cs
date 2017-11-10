using CdrFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CdrFramework.Northwind.Entities.Concrete
{
    public class Product:IEntity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }  // her product ın birde category si olsun diye bu
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
    }
}
