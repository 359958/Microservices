using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIcketBook.DataTier;
using TIcketBook.DataTier.Models;

namespace TIcketBook.DataTier.Repositories
{
    public class Movie : Repository<SampleMovie>, IMovie
    {
        public Movie(Movie_TicketContext movie_TicketContext) : base (movie_TicketContext)
        {
                
        }

        public async  Task<List<SampleMovie>> GetMovieInfo()
        {
            return await GetAll().ToListAsync();
        }
    }
}
