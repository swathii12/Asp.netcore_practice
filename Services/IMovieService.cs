using Asp.netcore_practice.Models;
using Asp.netcore_practice.ViewModels;

namespace Asp.netcore_practice.Services
{
    public interface IMovieService
    {
        void Add(MovieViewModel movie);

        List<Movie> GetAll();

        
        MovieGetByIdViewModel GetById(int id);

        void Delete(int id);

        Movie Update(int id,MovieViewModel movie);
        Movie GetMovie(int id);

    }
}
