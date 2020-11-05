using DevFramework.Core.CrossCuttingConcerns.Validation.FluentValidation;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.ValidationRules.FluentValidation;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using System.Collections.Generic;
using DevFramework.Core.Aspects.Postsharp;
using System.Transactions;
using DevFramework.Core.Aspects.Postsharp.ValidationAspects;
using DevFramework.Core.Aspects.Postsharp.TransactionAspects;
using DevFramework.Core.Aspects.Postsharp.CacheAspects;
using DevFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using DevFramework.Core.Aspects.Postsharp.LogAspects;
using DevFramework.Core.Aspects.Postsharp.PerformanceAspects;
using System.Threading;
using PostSharp.Aspects.Dependencies;
using DevFramework.Core.Aspects.Postsharp.AuthorizationAspects;
using System.Linq;
using AutoMapper;
using DevFramework.Core.Utilities.Mappings;

namespace DevFramework.Northwind.Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        private readonly IProductDAL _productDal;
        private readonly IMapper _mapper;
        public ProductManager(IProductDAL productDAL,IMapper mapper)
        {
            _productDal = productDAL;
            _mapper = mapper;

        }
        [FluentValidationAspect(typeof(ProductValidatior))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Product Add(Product product)
        {
            //ValidatorTool.FluentValidate(new ProductValidatior(), product);

            return _productDal.Add(product);
        }
        [CacheAspect(typeof(MemoryCacheManager))]
        //[LogAspect(typeof(FileLogger))]
        //[LogAspect(typeof(DatabaseLogger))]
        //[SecuredOperation(Roles = "Admin,Editor,Student")]
        public List<Product> GetAll()
        {
            //return _productDal.GetList().Select(p => new Product
            //{
            //    CategoryId = p.CategoryId,
            //    ProductId = p.ProductId,
            //    ProductName = p.ProductName,
            //    QuantityPerUnit = p.QuantityPerUnit,
            //    UnitPrice = p.UnitPrice
            //}).ToList();

            List<Product> productMap = _mapper.Map<List<Product>>(_productDal.GetList());
            return productMap;
        }

        public Product GetById(int id)
        {
            return _productDal.Get(x => x.ProductId == id);
        }
        [FluentValidationAspect(typeof(ProductValidatior))]
        [TransactionScopeAspect]
        public void TransactionalOperation(Product product1, Product product2)
        {

            _productDal.Add(product1);
            //Business Codes
            _productDal.Update(product2);

        }

        [FluentValidationAspect(typeof(ProductValidatior))]
        public Product Update(Product product)
        {
            //ValidatorTool.FluentValidate(new ProductValidatior(), product); Bu Yanlis Attribute Seklinde Olmasi lazim AOP(Aspect)

            return _productDal.Update(product);
        }
    }
}