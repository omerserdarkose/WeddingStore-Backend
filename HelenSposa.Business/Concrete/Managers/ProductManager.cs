using AutoMapper;
using HelenSposa.Business.Abstract;
using HelenSposa.Business.Aspects.Autofac;
using HelenSposa.Business.Constant;
using HelenSposa.Business.ValidationRules.FluentValidation;
using HelenSposa.Core.Aspects.Autofac;
using HelenSposa.Core.Utilities.Result;
using HelenSposa.DataAccess.Abstract;
using HelenSposa.Entities.Concrete;
using HelenSposa.Entities.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelenSposa.Core.Extensions;
using Microsoft.AspNetCore.Http;

namespace HelenSposa.Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        private IHttpContextAccessor _httpContextAccessor;
        private IMapper _mapper;

        public ProductManager(IProductDal productDal, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _productDal = productDal;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        //[SecuredOperation("admin")]
        //[ValidationAspect(typeof(ProductAddValidator))]
        //[CacheRemoveAscpect("IProductService.Get")]
        public IResult Add(ProductAddDto addedProduct)
        {
            var newProduct = _mapper.Map<Product>(addedProduct);
            newProduct.Idate=DateTime.Now;
            newProduct.IuserId= _httpContextAccessor.HttpContext.User.GetLoggedUserId();
            _productDal.Add(newProduct);
            newProduct.IsActive = true;
            return new SuccessResult(Messages.ProductAdded);
        }

        //[SecuredOperation("admin")]
        //[CacheRemoveAscpect("IProductService.Get")]
        public IResult Delete(int id)
        {
            var delProduct = _productDal.Get(x => x.Id == id);
            if (delProduct is null)
            {
                return new ErrorResult(Messages.ProductNotFound);
            }
            delProduct.UuserId= _httpContextAccessor.HttpContext.User.GetLoggedUserId();
            delProduct.Udate=DateTime.Now;
            delProduct.IsActive = false;
            _productDal.Update(delProduct);
            return new SuccessResult(Messages.ProductDeleted);
        }

        //[SecuredOperation("admin,worker")]
        //[CacheAspect(duration: 10)]
        public IDataResult<List<ProductShowDto>> GetAll()
        {
            var expenseTypeList = _productDal.GetList();
            var mapProductList = _mapper.Map<List<ProductShowDto>>(expenseTypeList);
            return new SuccessDataResult<List<ProductShowDto>>(mapProductList);
        }

        //[SecuredOperation("admin")]
        //[ValidationAspect(typeof(ProductUpdateValidator))]
        //[CacheRemoveAscpect("IProductService.Get")]
        public IResult Update(int id,ProductUpdateDto updatedProduct)
        {
            var updProduct = _productDal.Get(x => x.Id == id);
            if (updProduct is null)
            {
                return new ErrorResult(Messages.ProductNotFound);
            }
            updProduct = _mapper.Map(updatedProduct,updProduct);
            updProduct.UuserId = _httpContextAccessor.HttpContext.User.GetLoggedUserId();
            updProduct.Udate=DateTime.Now;
            _productDal.Update(updProduct);
            return new SuccessResult(Messages.ProductUpdated);
        }

        public bool IsExists(int id)
        {
            var result = _productDal.Any(x => x.Id == id);

            return result;
        }
    }
}
