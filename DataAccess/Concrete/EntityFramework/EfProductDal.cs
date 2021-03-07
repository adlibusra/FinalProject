using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{

    //NuGet : Entity Framwork pakaet olarak geliyor 
   public class EfProductDal : EfEntityRepositoryBase<Product,NorthWindContext>,IProductDal
    {
        
    }
}
