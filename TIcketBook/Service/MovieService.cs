using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIcketBook.DataTier.Models;
using TIcketBook.DataTier.Repositories;



namespace TIcketBook.Service
{
    public class MovieService : IMovieService
    {
        private readonly IMovie _movie;
        private readonly IMovieShow _movieshow;
        public MovieService(IMovie movie , IMovieShow movieShow)
        {
            _movie = movie;
            _movieshow = movieShow;
        }
        public async Task<List<SampleMovie>> GetAllMovie()
        {
            return await _movie.GetMovieInfo();
        }
        public async Task<List<MovieShow>> GetAllshowsMovie()
        {
            List<SampleMovie> movies = await GetAllMovie();
            List<SampleMovieShowingDetails> moviesshow = await _movieshow.GetMovieshowInfo();

            var result = (from p in movies
                          join o in moviesshow on p.MovieId equals o.MovieId
                          select new MovieShow
                          {
                              MovieId = p.MovieId,
                              MovieName = p.MovieName,
                              Show = o.ShowId
                          }).ToList();

            return result;

            
        }
    }
}
