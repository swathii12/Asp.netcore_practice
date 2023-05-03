using Asp.netcore_practice.Context;
using Asp.netcore_practice.Models;
using Asp.netcore_practice.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Asp.netcore_practice.Services
{
    public class MovieService : IMovieService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public MovieService(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add(MovieViewModel movie)
        {
            var _movie = new Movie()
            {
               
                MovieName = movie.MovieName,
                Description = movie.Description,
                Price = movie.Price,
                ImageUrl = movie.ImageUrl,
                MovieCategory = movie.MovieCategory,
                CinemaId=movie.CinemaId,
                ProducerId=movie.ProducerId

            };
            _context.Movies.Add(_movie);
            _context.SaveChanges();


            foreach (var id in movie.ActorId)
            {
                var _actor_movie = new Actor_Movie()
                {
                    MovieId = _movie.MovieId,
                    ActorId = id,
                    
                };

                _context.Actors_Movies.Add(_actor_movie);
                _context.SaveChanges();
            }
            
        }

        public void Delete(int id)
        {
            var movie = _context.Movies.FirstOrDefault(n => n.MovieId == id);
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }

        public List<MovieViewModel> GetAll()
        {
            return _context.Movies.Select(a=>_mapper.Map<Movie,MovieViewModel>(a)).ToList();
        }

        public MovieGetByIdViewModel GetById(int id)
        {
            var _moviewithactors = _context.Movies.Where(n => n.MovieId == id).Include(a=>a.Actor_Movies).Select(movie => new MovieGetByIdViewModel()
            {
                MovieId = movie.MovieId,
                MovieName = movie.MovieName,
                Description = movie.Description,
                Price = movie.Price,
                ImageUrl = movie.ImageUrl,
                MovieCategory = movie.MovieCategory,
                CinemaId= movie.Cinema.CinemaId,
                ProducerId = movie.producer.ProducerId,
                ActorNames = movie.Actor_Movies.Select(n => n.Actor.ActorName).ToList()
            }).FirstOrDefault();

            return _moviewithactors;
        }

        public MovieViewModel Update(int id, MovieViewModel movie)
        {
            var _movie = _context.Movies.FirstOrDefault(n => n.MovieId == id);
            if(_movie!=null)
            {
             
                _movie.MovieName = movie.MovieName;
                _movie.Description = movie.Description;
                _movie.Price = movie.Price;
                _movie.ImageUrl = movie.ImageUrl;
                _movie.MovieCategory = movie.MovieCategory;
                _movie.CinemaId = movie.CinemaId;
                _movie.ProducerId = movie.ProducerId;

                _context.SaveChanges();
            };
            return _mapper.Map<Movie,MovieViewModel>(_movie) ;

           
        }

        public Movie GetMovie(int id)
        {
           var movieModel= _context.Movies.FirstOrDefault(n => n.MovieId == id);
            return movieModel;

        }
    }
}
