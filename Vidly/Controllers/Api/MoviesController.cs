using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/movies
        public IEnumerable<MovieDto> GetMovies()
        {
            return _context.Movies.Include(m=>m.GenreType).ToList().Select(Mapper.Map<Movie, MovieDto>);
        }

        //GET /api/movies/id
        public IHttpActionResult GetMovie(int id)
        {
            var mov = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (mov == null)
                return NotFound();
            else
                return Ok(Mapper.Map<Movie, MovieDto>(mov));
        }


        //POST /api/movies/id
        [HttpPost]
        public IHttpActionResult AddMovie(MovieDto movDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var mov = Mapper.Map<MovieDto, Movie>(movDto);
            _context.Movies.Add(mov);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + mov.Id), movDto);
        }


        //PUT /api/movies/id
        [HttpPut]
        public void EditMovie(int id, MovieDto movDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map<MovieDto,Movie>(movDto, movInDb);
            _context.SaveChanges();
        }

        //DELETE /api/movies/id
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movInDb);
            _context.SaveChanges();
        }
    }
}
