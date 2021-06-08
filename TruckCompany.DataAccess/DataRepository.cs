using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TruckCompany.DataAccess
{
    public class DataRepository:IDataRepository
    {
        public readonly TruckCompanyDBContext dBContext;

        public DataRepository(TruckCompanyDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public IQueryable<TEntity> Query<TEntity>() where TEntity : class
        {
            return dBContext.Set<TEntity>();
        }

        void IDataRepository.Delete<TEntity>(TEntity entity)
        {
            dBContext.Remove(entity);
        }

        void IDataRepository.Insert<TEntity>(TEntity entity)
        {
            dBContext.Add(entity);
        }

        void IDataRepository.Update<TEntity>(TEntity entity)
        {
            dBContext.Update(entity);
        }
    }
}
