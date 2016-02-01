using System;

namespace Company.Example.Core
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}