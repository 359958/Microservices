using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIcketBook.DataTier.Models;
using TIcketBook.DataTier;

namespace TIcketBook.Service
{
    public interface IMovieService
    {
        Task<List<SampleMovie>> GetAllMovie();
        Task<List<MovieShow>> GetAllshowsMovie();
    }
}
