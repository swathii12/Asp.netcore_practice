using Asp.netcore_practice.Models;
using Asp.netcore_practice.ViewModels;

namespace Asp.netcore_practice.Services
{
    public interface IActorService
    {
        ActorGetByIdViewModel GetById(int id);
        void AddActor(ActorViewModel actor);

        List<Actor> GetAllActors();

        void Delete(int id);

        Actor Update(int id, ActorViewModel actor);
    }
}
