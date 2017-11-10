using CdrFramework.Core.DataAccess;
using CdrFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CdrFramework.Northwind.DataAccess.Abstract
{
    public interface ICategoryDal:IEntityRepository<Category>
    {
        //custom operasyon
        /* mesela ben bir  kategorinin altıda kaç tane ürün var bunu öğrenmek istiyorum. bu kategori ile alakalı bir operasyon .. o zaman önce ICategoryDal ın altına operasyonu tanımlıcam
         daha sonra gidicem EFCategoryDal sınıfına gerekliliği implement edicem..önce ınterface sonra sınıfa.. bu şeklde yapım devam edicek*/
    }
}
