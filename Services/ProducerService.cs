using Asp.netcore_practice.Context;
using Asp.netcore_practice.Models;
using Asp.netcore_practice.ViewModels;

namespace Asp.netcore_practice.Services
{
    public class ProducerService:IProducerService
    {
        private readonly AppDbContext _context;

        public ProducerService(AppDbContext context)
        {
            _context = context;
        }

        public void AddProducer(ProducerViewModel producer)
        {
            var _producer = new Producer()
            {
                // ActorId = actor.ActorId,
                ProfilePictureUrl = producer.ProfilePictureUrl,
                ProducerName = producer.ProducerName,
                Bio = producer.Bio


            };
            _context.Producers.Add(_producer);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var producer = _context.Producers.FirstOrDefault(n => n.ProducerId == id);
            _context.Producers.Remove(producer);
            _context.SaveChanges();
        }

        public List<Producer> GetAllProducers()
        {
            var producers = _context.Producers.ToList();
            return producers;
        }

        public ProducerGetByIdViewModel GetById(int id)
        {
            var producer = _context.Producers.Where(n => n.ProducerId == id).Select(producer => new ProducerGetByIdViewModel()
            {
                ProducerId = producer.ProducerId,
                ProfilePictureUrl = producer.ProfilePictureUrl,
                ProducerName = producer.ProducerName,
                Bio = producer.Bio,
                Movies = _context.Movies.Select(n => n.MovieName).ToList()

            }).FirstOrDefault();
            return producer;
        }

        public Producer Update(int id, ProducerViewModel producer)
        {
            var _producer = _context.Producers.FirstOrDefault(n => n.ProducerId == id);
            if (_producer != null)
            {
                _producer.ProfilePictureUrl = producer.ProfilePictureUrl;
                _producer.ProducerName = producer.ProducerName;
                _producer.Bio = producer.Bio;

                _context.SaveChanges();
            }
            return _producer;
        }
    }
}
