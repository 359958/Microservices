using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TIcketBook.Service;
using TIcketBook.DTO.Model;
using TIcketBook.DataTier.Models;
using TIcketBook.Helper;
using AutoMapper;


namespace TIcketBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieShowsController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;
        public MovieShowsController(IMovieService movieService , IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }
        // GET: api/MovieShows
        [HttpGet]
        public async Task<ActionResult<List<MovieShowDTO>>> Get()
        {
            List<MovieShow> movies = await _movieService.GetAllshowsMovie();
            List<MovieShowDTO> moviesdto = _mapper.Map<List<MovieShowDTO>>(movies);
            return moviesdto;
        }

        // GET: api/MovieShows/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/MovieShows
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/MovieShows/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
