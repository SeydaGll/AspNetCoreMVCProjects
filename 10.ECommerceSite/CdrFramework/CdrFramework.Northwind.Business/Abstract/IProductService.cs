using CdrFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CdrFramework.Northwind.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll(); // bütün productları dön. bütün product ların listelenmesi
        List<Product> GetByCategoryId(int categoryId);   // ben bir category vereyim onun altındaki ürünleri getirsin
        void Add(Product product);
        void Update(Product product);
        void Delete(int productId);
        Product GetById(int productId);  // tek bir tane product ı geriye döndüren metodum
    }
}
