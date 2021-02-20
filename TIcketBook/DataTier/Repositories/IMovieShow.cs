using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIcketBook.DataTier.Models;

namespace TIcketBook.DataTier.Repositories
{
    public interface IMovieShow : IRepository<SampleMovieShowingDetails>
    {
        Task<List<SampleMovieShowingDetails>> GetMovieshowInfo();
    }
}
