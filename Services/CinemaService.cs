using Asp.netcore_practice.Context;
using Asp.netcore_practice.Models;
using Asp.netcore_practice.ViewModels;
using AutoMapper;

namespace Asp.netcore_practice.Services
{
    public class CinemaService:ICinemaService
    {

            private readonly AppDbContext _context;
            private readonly IMapper _mapper;

            public CinemaService(AppDbContext context,IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public void AddCinema(CinemaViewModel cinema)
            {
                var _cinema = new Cinema()
                {
                    CinemaLogo = cinema.CinemaLogo,
                    CinemaName=cinema.CinemaName,
                    description=cinema.description
                };

                _context.Cinemas.Add(_cinema);
                _context.SaveChanges();
            }

            public void Delete(int id)
            {
                var cinema = _context.Cinemas.FirstOrDefault(n => n.CinemaId == id);
                _context.Cinemas.Remove(cinema);
                _context.SaveChanges();
            }

            public List<CinemaViewModel> GetAllCinemas()
            {
                var cinemas = _context.Cinemas.Select(a=>_mapper.Map<Cinema,CinemaViewModel>(a)).ToList();
                return cinemas;
            }

            public CinemaGetByIdViewModel GetById(int id)
            {
                var cinema = _context.Cinemas.Where(n => n.CinemaId == id).Select(cinema => new CinemaGetByIdViewModel()
                {
                    CinemaId = cinema.CinemaId,
                    CinemaLogo = cinema.CinemaLogo,
                    CinemaName = cinema.CinemaName,
                    description = cinema.description,
                    MovieNames = _context.Movies.Select(n => n.MovieName).ToList()

                }).FirstOrDefault();
                return cinema;
            }

        public CinemaViewModel Update(int id, CinemaViewModel cinema)
        {
            var _cinema = _context.Cinemas.FirstOrDefault(n => n.CinemaId == id);
            if (_cinema != null)
            {
                _cinema.CinemaLogo = cinema.CinemaLogo;
                _cinema.CinemaName = cinema.CinemaName;
                _cinema.description = cinema.description;

                _context.SaveChanges();
            }

            
            return _mapper.Map<Cinema,CinemaViewModel>(_cinema) ;
        }  
        
    }

}

