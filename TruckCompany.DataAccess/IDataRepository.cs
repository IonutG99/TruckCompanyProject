using System.Linq;

namespace TruckCompany.DataAccess
{
    public interface IDataRepository
    {
        IQueryable<TEntity> Query<TEntity>() where TEntity : class;

        void Delete<TEntity>(TEntity entity) where TEntity : class;

        void Update<TEntity>(TEntity entity) where TEntity : class;

        void Insert<TEntity>(TEntity entity) where TEntity : class;
    }
}
