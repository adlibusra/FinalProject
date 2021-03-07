using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{

    //NuGet : Entity Framwork pakaet olarak geliyor 
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthWindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetailDtos()
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryID equals c.CategoryId
                             select new ProductDetailDto
                             {
                                 ProductID = p.ProductID,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 UnitsInStock = p.UnitsInStock
                             };
                return result.ToList();
            }
        }
    }
}
