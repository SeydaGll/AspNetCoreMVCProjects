using CdrFramework.Core.DataAccess.EntityFramework;
using CdrFramework.Northwind.DataAccess.Abstract;
using CdrFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CdrFramework.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EFCategoryDal:EFEntityRepositoryBase<Category,NorthwindContext>,ICategoryDal //nhibernate tarafnda da CAtegoryDal olabilir o yüzden enetityframework old bildirmek içn Ef yazdık başına 
    {
        /*Custom opaerasyon.. sadece Category nesnesi için gerekli olan bir ihtiyac vardır ama diğerlerinde yoktur o zaman gelip buaya yazarım.. ama select ınsert delete işlmelri için ise
        bir daha bunu yazmama gerek yok çünkü zaten ben bunları entityframe workün base repository sınıfında yazmıtım*/
    }
}
