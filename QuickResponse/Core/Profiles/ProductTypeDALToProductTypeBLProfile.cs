using AutoMapper;
using QuickResponse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Core.Profiles
{
    public class ProductTypeDALToProductTypeBLProfile:Profile
    {
        public const string ViewModel = "ProductTypeDALToProductTypePLProfile";

        public override string ProfileName => ViewModel;
        public ProductTypeDALToProductTypeBLProfile()
        {
            var p = new Data.Models.ProductType();
            this.CreateMap<Data.Models.ProductType, ProductType>();
        }
    }
}
