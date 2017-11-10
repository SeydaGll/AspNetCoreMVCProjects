using CdrFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CdrFramework.Core.DataAccess
{
    public interface IEntityRepository<T> where T:class,IEntity,new() 
    {
        //where(q=>q.CAtegoryId==id) //expression.linq expression ı.bunun ifadeleri metodun içerisine geçirebilmek için linq içerisinde yer alan expressıon ifadesinden faydalanabilirm
        T Get(Expression<Func<T,bool>> filter=null);  // veri tabanından bir tane nesneyi alıp geriye dönücek. bunu yaparken ben illaki belli ifadeler kullanırım derim ki mesela category nin category ıd si şu olanı getir
        List<T> GetList(Expression<Func<T, bool>> filter = null); // birden fazla nesne göndermek için. tüm productlar gelsin .. içerisine hiç bir ifade göndermeden o yüzde null dedik
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
