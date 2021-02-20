using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIcketBook.DataTier;
using TIcketBook.DataTier.Models;


namespace TIcketBook.DataTier.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private readonly Movie_TicketContext _movie_TicketContext;
        public Repository(Movie_TicketContext movie_TicketContext)
        {
            _movie_TicketContext = movie_TicketContext;
        }
        public Task<TEntity> AddAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return _movie_TicketContext.Set<TEntity>().AsQueryable();
            }
            catch (Exception ex)
            {

                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public IQueryable<TEntity> GetbyID(TEntity entity)
        {
            try
            {
                return _movie_TicketContext.Set<TEntity>();
            }
            catch (Exception ex)
            {

                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
