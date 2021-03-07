using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{ 

    // context : Db Tablolarıyla proje classlarını bağlamak 

   public class NorthWindContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // Hangi veri tabanıyla ilişkili projem 
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Northwind; Trusted_Connection=true;"); // Sql  servera nasıl bağlanıcağımı belirti,yorum

        }
        public DbSet<Product> Products { get; set; } //Bağlama işlemi 

        public DbSet<Category> Categories { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet <Order> Orders { get; set; }

    }
}
