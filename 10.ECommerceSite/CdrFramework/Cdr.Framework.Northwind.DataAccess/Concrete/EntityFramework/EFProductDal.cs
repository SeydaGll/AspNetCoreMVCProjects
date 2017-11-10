using CdrFramework.Core.DataAccess.EntityFramework;
using CdrFramework.Northwind.DataAccess.Abstract;
using CdrFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CdrFramework.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EFProductDal: EFEntityRepositoryBase<Product, NorthwindContext>,IProductDal
    {
        //ürünle ilgili custom operasyonun varsa buraya yazabilirsin
    }
}
