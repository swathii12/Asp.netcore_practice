using Asp.netcore_practice.Context;
using Asp.netcore_practice.Models;
using Asp.netcore_practice.ViewModels;

namespace Asp.netcore_practice.Services
{
    public class MovieService : IMovieService
    {
        private readonly AppDbContext _context;

        public MovieService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(MovieViewModel movie)
        {
            var _movie = new Movie()
            {
                //MovieId = movie.MovieId,
                MovieName = movie.MovieName,
                Description = movie.Description,
                Price = movie.Price,
                ImageUrl = movie.ImageUrl,
                StartDate = movie.StartDate,
                EndDate = movie.EndDate,
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

        public List<Movie> GetAll()
        {
            return _context.Movies.ToList();
        }

        public MovieGetByIdViewModel GetById(int id)
        {
            var _moviewithactors = _context.Movies.Where(n => n.MovieId == id).Select(movie => new MovieGetByIdViewModel()
            {
                MovieId = movie.MovieId,
                MovieName = movie.MovieName,
                Description = movie.Description,
                Price = movie.Price,
                ImageUrl = movie.ImageUrl,
                StartDate = movie.StartDate,
                EndDate = movie.EndDate,
                MovieCategory = movie.MovieCategory,
                CinemaId= movie.Cinema.CinemaId,
                ProducerId = movie.producer.ProducerId,
                ActorNames = movie.Actor_Movies.Select(n => n.Actor.ActorName).ToList()
            }).FirstOrDefault();

            return _moviewithactors;
        }

        public Movie Update(int id, MovieViewModel movie)
        {
            var _movie = _context.Movies.FirstOrDefault(n => n.MovieId == id);
            if(_movie!=null)
            {
                //_movie.MovieId = movie.MovieId;
                _movie.MovieName = movie.MovieName;
                _movie.Description = movie.Description;
                _movie.Price = movie.Price;
                _movie.ImageUrl = movie.ImageUrl;
                _movie.StartDate = movie.StartDate;
                _movie.EndDate = movie.EndDate;
                _movie.MovieCategory = movie.MovieCategory;
                _movie.CinemaId = movie.CinemaId;
                _movie.ProducerId = movie.ProducerId;

                _context.SaveChanges();
            };
            return _movie;

           
        }

        public Movie GetMovie(int id)
        {
           var movieModel= _context.Movies.FirstOrDefault(n => n.MovieId == id);
            return movieModel;

        }
    }
}
