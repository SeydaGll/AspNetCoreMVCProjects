using CdrFramework.Northwind.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using CdrFramework.Northwind.Entities.Concrete;
using CdrFramework.Northwind.DataAccess.Abstract;
using System.Threading.Tasks;

namespace CdrFramework.Northwind.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public  List<Category> GetAll()
        {
            return  _categoryDal.GetList();
        }
    }
}
