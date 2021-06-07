using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace TruckCompany.DataAccess.SqlServer
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly TruckCompanyDBContext dBContext;

        public UnitOfWork(TruckCompanyDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public void Commit()
        {
            using(var scope=new TransactionScope())
            {
                dBContext.SaveChanges();
                scope.Complete();
            }
        }
    }
}
