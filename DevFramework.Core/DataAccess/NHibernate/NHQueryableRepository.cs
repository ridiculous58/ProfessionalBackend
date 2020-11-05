using DevFramework.Core.Entities;
using System.Linq;

namespace DevFramework.Core.DataAccess.NHibernate
{
    public class NHQueryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        private NHibernateHelper _nHibernateHelper;
        private IQueryable<T> _entites;

        public NHQueryableRepository(NHibernateHelper nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;
        }
        public IQueryable<T> Table => this.Entities;

        public IQueryable<T> Entities => _entites ?? (_entites = _nHibernateHelper.OpenSession().Query<T>());

    }
}
