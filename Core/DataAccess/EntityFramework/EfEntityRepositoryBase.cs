using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase <TEntity, TContext>: IEntityRepository<TEntity>
        where TEntity: class, IEntity, new() // Krallar veri tabanı tablosu
        where TContext: DbContext ,new ()
    {
        public void Add(TEntity entity)
        {
            //using : IDisposable pattern implementation of c#// c# a özgü // Belleği hızlıca temizleme 
            using (TContext context = new TContext()) // using içine ytazdığımız nesneler kullanım bittikten sonra bellekten atılır 
            {
                var addedEntity = context.Entry(entity); // Entity frameworke özgü // ilişkilendirdi
                addedEntity.State = EntityState.Added; // Ekleme // ekleme olarak set et
                context.SaveChanges(); // Ekledi
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext()) // using içine ytazdığımız nesneler kullanım bittikten sonra bellekten atılır 
            {
                var deletedEntity = context.Entry(entity); // Entity frameworke özgü // ilişkilendirdi
                deletedEntity.State = EntityState.Deleted; // Ekleme // ekleme olarak set et
                context.SaveChanges(); // Ekledi
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null) // Parametre olarak göndereceğimiz şey lambda
        {
            using (TContext context = new TContext()) // TEk data getirecek
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext()) // using içine ytazdığımız nesneler kullanım bittikten sonra bellekten atılır 
            {
                var updatedEntity = context.Entry(entity); // Entity frameworke özgü // ilişkilendirdi
                updatedEntity.State = EntityState.Modified; // Ekleme // ekleme olarak set et
                context.SaveChanges(); // Ekledi
            }
        }
    }
}
