using DevFramework.Core.DataAccess;
using DevFramework.Northwind.Entities.ComplexType;
using DevFramework.Northwind.Entities.Concrete;
using System.Collections.Generic;

namespace DevFramework.Northwind.DataAccess.Abstract
{
    public interface IProductDAL : IEntityRepository<Product>
    {
        List<ProductDetail> GetProductDetails();
    }
}
