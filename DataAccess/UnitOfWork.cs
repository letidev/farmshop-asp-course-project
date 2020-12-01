using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace FarmShop.DataAccess {
    public class UnitOfWork : IDisposable {
        public DbContext Context { get; private set; }
        public IDbContextTransaction Transaction { get; set; }

        public UnitOfWork() {
            Context = new MyDbContext();
        }

        public void BeginTransaction() {
            Transaction = Context.Database.BeginTransaction();
        }

        public void Commit() {
            Transaction.Commit();
        }

        public void Rollback() {
            Transaction.Rollback();
        }

        public void Dispose() {
            Transaction.Dispose();
            Context.Dispose();
        }
    }
}
