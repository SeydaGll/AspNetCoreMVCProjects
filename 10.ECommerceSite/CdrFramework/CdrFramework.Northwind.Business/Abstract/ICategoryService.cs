using CdrFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CdrFramework.Northwind.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();  // tüm kategorileri getir
    }
}
