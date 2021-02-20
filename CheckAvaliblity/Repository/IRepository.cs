using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckAvaliblity.Repository
{
     public interface IRepository<TEntity> where TEntity : class, new()
    {
        IQueryable<TEntity> getAll();
        IQueryable<TEntity> getByID(string ShowID);
    }
}
