using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{

    //SOLİD 
    //open Closed Principle // mevcut kodlarına dokunmaa 
    class Program
    {
        static void Main(string[] args)
        {
            ProductTest();
            Console.ReadLine();
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }

        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductName);

            }
        }
    }
}
