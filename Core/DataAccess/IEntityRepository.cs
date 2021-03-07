using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    // Core Katmanı diğer katmanları referans almaz
    //Generic Constraint : Generic Kısıt 
    //Class : Referans tip olabilir 
    // IEntity olabilir yada IEntity  implemente eden nesne olbilir
    //New (): new lenebilir olamalı IEntity new lenemez
    //Namespace :isim uzayı

   public interface IEntityRepository<T> where T:class, IEntity,new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter=null); // filtreleme yapıyoruz
        T Get(Expression<Func<T, bool>> filter);

        void Add(T entity);

        void Delete(T entity);

        void Update(T entity);


        // kategorye göre filtrele
       // List<T> GetAllByCategory(int categoryId);
    }
}
