using Asp.netcore_practice.Models;
using Asp.netcore_practice.ViewModels;

namespace Asp.netcore_practice.Services
{
    public interface IMovieService
    {
        void Add(MovieViewModel movie);

        List<MovieViewModel> GetAll();

        
        MovieGetByIdViewModel GetById(int id);

        void Delete(int id);

        MovieViewModel Update(int id,MovieViewModel movie);
        Movie GetMovie(int id);

    }
}
