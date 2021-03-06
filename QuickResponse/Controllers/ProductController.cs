using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuickResponse.Core.Interfaces;
using QuickResponse.Data.Models;
using QuickResponse.Data.Repositories;
using QuickResponse.Models.ViewModels;
using QuickResponse.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Controllers
{
    public class ProductController:Controller
    {
        private UnitOfWorkRepository _uow;
        private IMapper _mapper;
        public ProductController(IUnitOfWOrkRepositroy unitOfWOrkRepositroy, IMapper mapper)
        {
            this._uow = (UnitOfWorkRepository)unitOfWOrkRepositroy;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult CreateProduct() => View();

        [HttpPost]
        public IActionResult CreateProduct(ProductTypeCreateModel productTypeCreate )
        {
            var validator = new ProductCreateValidator();
            if (validator.Validate(productTypeCreate).IsValid)
            {
                var productType = this._mapper.Map<ProductTypeCreateModel, ProductType>(productTypeCreate);
                if (this._uow.ProductTypeRepository.Save(productType))
                {
                    return RedirectToAction("CreatePost", "Post");
                }
                else
                {
                   return RedirectToAction("CreateProduct");
                }
            }
            return RedirectToAction("CreateProduct");
        }
    }
}
