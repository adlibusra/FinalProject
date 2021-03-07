using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{

    //Add REference to entities // Entities katmanını kullanıcam ampülle onu seçtim
    public interface IProductDal: IEntityRepository<Product>
    {

        List<ProductDetailDto> GetProductDetailDtos();
        // interdface metotları default publictir
        

    }
}


//Code REfactoring yaptık 