using System;
using Company.Example.Core;

namespace Company.Example.Infrastructure.EntityFramework.UnitOfWorkAware
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly ExampleDatabaseContext _context;

		public EfUnitOfWork(ExampleDatabaseContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            this._context = context;
        }

        #region IUnitOfWork Members
        public void Commit()
        {
            if (_context != null)
            {
                _context.SaveChanges();
            }
        }

        #endregion

        #region IDispassable
        private bool _disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
