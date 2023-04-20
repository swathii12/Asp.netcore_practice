using Asp.netcore_practice.Models;
using Asp.netcore_practice.ViewModels;

namespace Asp.netcore_practice.Services
{
    public interface ICinemaService
    {
        CinemaGetByIdViewModel GetById(int id);
        void AddCinema(CinemaViewModel cinema);

        List<Cinema> GetAllCinemas();

        void Delete(int id);

        Cinema Update(int id, CinemaViewModel actor);
    }
}
