using CdrFramework.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CdrFramework.Core.DataAccess.EntityFramework
{
    public class EFEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);  //eklenecek olan entity i oluşturalım.context in içine girdi
                addedEntity.State = EntityState.Added;// context in içine girdi ama bunun durumu ne? ne yapıcaz bunu.. state ini değişiriyorum ve entityframework bu duruma göre yapacağı işlemi anlıyor
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);  //daha önce hiç görmediğiniz entity ekleme yöntemi
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public  TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);  // gelen filtreye göre bir tane varlık bulucak ve geriye dönücek
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null) //
        {
            using (var context = new TContext())
            {
                return filter == null  // filtereyi kontrol edicez null sa eğer şunu yap. kullanıcı q şöyleyse gibi bir filtre göndermediyse alttaki çalışşsın gönderdiyse diğeri çalışsn
                    ? context.Set<TEntity>().ToList()  //BÜTÜn varlıkları döndüm
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);  
                updatedEntity.State = EntityState.Modified;  // değiştirildi olarak değiştiriyorum
                context.SaveChanges();
            }
        }
    }
}