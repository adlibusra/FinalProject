using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products; // Alt çizgi global değişkenler // naming commention
        public InMemoryProductDal() // ctor constructer
        {
            _products = new List<Product>
            { 
                // Bellekte ürün oluşturdum // Oracle ,sql den geliyomuş gibi simüle ettik 

                new Product{ProductID=1, CategoryID=1 ,  ProductName="Bardak",  UnitPrice=15, UnitsInStock=15},
                new Product{ProductID=2, CategoryID=1 ,  ProductName="Kamera",  UnitPrice=500, UnitsInStock=3},
                new Product{ProductID=3, CategoryID=2 ,  ProductName="Telefon",  UnitPrice=1500, UnitsInStock=2},
                new Product{ProductID=4, CategoryID=2 ,  ProductName="Klavye",  UnitPrice=150, UnitsInStock=65},
                new Product{ProductID=5, CategoryID=2 ,  ProductName="Fare",  UnitPrice=85, UnitsInStock=1}
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product) //.remote olmaz çünkü süslü parantez içinde ürünlerim
        {
            //Product productToDelete= null; */// linQ sistemi Product ID sine göre:Dile göülü sorgulama
            //foreach ( var p  in _products) // listyi dolaş 
            //{
            //    if (product.ProductId== p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}

            // => Lambda

            Product productToDelete; // linQ
            productToDelete = _products.SingleOrDefault(p => p.ProductID == product.ProductID);
            // Method. TEk tek dolaşma kısa yolu forech yapıyor 

            _products.Remove(productToDelete);

        }

        public List<Product> GetAll()
        {
            return _products;
        }



        public void Update(Product product)
        {
            //  Gönderdiğim ürün Id sine sahip olanlistedeki  ürün bul

            Product productToUpdate;
            productToUpdate = _products.SingleOrDefault(p => p.ProductID == product.ProductID);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryID = product.CategoryID;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            productToUpdate.UnitPrice = product.UnitPrice;

        }
        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryID == categoryId).ToList();
            //Where  yeni bir liste haline getir ve onu döndür
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetailDtos()
        {
            throw new NotImplementedException();
        }
    }
}
