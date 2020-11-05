using DevFramework.Core.DataAccess.NHibernate;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Entities.Concrete;

namespace DevFramework.Northwind.DataAccess.Concrete.NHibernate
{
    public class NhCategoryDal:NHEntityRepositoryBase<Category>,ICategoryDAL
    {
        public NhCategoryDal(NHibernateHelper nHibernateHelper):base(nHibernateHelper)
        {

        }
    }
}
