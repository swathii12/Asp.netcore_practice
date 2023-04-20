using Asp.netcore_practice.Context;
using Asp.netcore_practice.Models;
using Asp.netcore_practice.ViewModels;

namespace Asp.netcore_practice.Services
{
    public class ActorService : IActorService
    {
        private readonly AppDbContext _context;

        public ActorService(AppDbContext context)
        {
            _context = context;
        }

        public void AddActor(ActorViewModel actor)
        {
            var _actor = new Actor()
            {
               // ActorId = actor.ActorId,
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

        public List<Actor> GetAllActors()
        {
            var actors = _context.Actor.ToList();
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

        public Actor Update(int id, ActorViewModel actor)
        {
            var _actor = _context.Actor.FirstOrDefault(n => n.ActorId == id);
            if (_actor != null)
            {
                _actor.ProfilePictureUrl = actor.ProfilePictureUrl;
                _actor.ActorName = actor.ActorName;
                _actor.Bio = actor.Bio;

                _context.SaveChanges();
            }
            return _actor;
        }
    }
}
