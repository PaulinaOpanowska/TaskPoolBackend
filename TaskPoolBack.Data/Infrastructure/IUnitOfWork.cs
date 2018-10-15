using System;
using System.Collections.Generic;
using System.Text;

namespace TaskPoolBack.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
