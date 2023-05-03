using Asp.netcore_practice.Context;
using Asp.netcore_practice.Models;
using Asp.netcore_practice.ViewModels;
using AutoMapper;

namespace Asp.netcore_practice.Services
{
    public class ActorService : IActorService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ActorService(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddActor(ActorViewModel actor)
        {
            var _actor = new Actor()
            {
              
                ProfilePictureUrl = actor.ProfilePictureUrl,
                ActorName = actor.ActorName,
                Bio = actor.Bio


            };
            _context.Actor.Add(_actor);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var actor = _context.Actor.FirstOrDefault(n => n.ActorId == id);
            _context.Actor.Remove(actor);
            _context.SaveChanges();
        }

        public List<ActorViewModel> GetAllActors()
        {
            var actors = _context.Actor.Select(a=>_mapper.Map<Actor,ActorViewModel>(a)).ToList();
            return actors;
        }

        public ActorGetByIdViewModel GetById(int id)
        {
            var actor = _context.Actor.Where(n => n.ActorId == id).Select(actor => new ActorGetByIdViewModel()
            {
                ActorId = actor.ActorId,
                ProfilePictureUrl = actor.ProfilePictureUrl,
                ActorName = actor.ActorName,
                Bio = actor.Bio,
                MovieNames = _context.Actors_Movies.Select(n => n.Movie.MovieName).ToList()

            }).FirstOrDefault();
            return actor;
        }

        public ActorViewModel Update(int id, ActorViewModel actor)
        {
            var _actor = _context.Actor.FirstOrDefault(n => n.ActorId == id);
            if (_actor != null)
            {
                _actor.ProfilePictureUrl = actor.ProfilePictureUrl;
                _actor.ActorName = actor.ActorName;
                _actor.Bio = actor.Bio;

                _context.SaveChanges();
            }
            return _mapper.Map<Actor,ActorViewModel>(_actor);
        }
    }
}
