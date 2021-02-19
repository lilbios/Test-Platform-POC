using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Platform_POC.Data.Interfaces
{
    public interface IGenericRepository<TEntity>: IRepository<TEntity> where TEntity: class
    {
    }
}
