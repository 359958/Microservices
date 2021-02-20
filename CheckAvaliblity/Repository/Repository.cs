using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckAvaliblity.Models;
using Microsoft.EntityFrameworkCore;

namespace CheckAvaliblity.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private readonly MovieContext _movieContext;
        public Repository(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        public IQueryable<TEntity> getAll()
        {
            try
            {
                return _movieContext.Set<TEntity>().AsQueryable();
            }
            catch (Exception Ex)
            {

                throw new Exception($"Couldn't retrieve entities: {Ex.Message}");
            }
        }

        public IQueryable<TEntity> getByID(string ShowID)
        {
            throw new NotImplementedException();
        }
    }
}
