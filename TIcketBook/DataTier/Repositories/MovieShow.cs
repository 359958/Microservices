using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIcketBook.DataTier;
using TIcketBook.DataTier.Models;

namespace TIcketBook.DataTier.Repositories
{
    public class MovieshowRepository : Repository<SampleMovieShowingDetails>, IMovieShow
    {
        public MovieshowRepository(Movie_TicketContext movie_TicketContext) : base (movie_TicketContext)
        {
                
        }

        public async  Task<List<SampleMovieShowingDetails>> GetMovieshowInfo()
        {
            return await GetAll().ToListAsync();
        }
    }
}
