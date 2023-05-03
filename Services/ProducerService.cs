using Asp.netcore_practice.Context;
using Asp.netcore_practice.Models;
using Asp.netcore_practice.ViewModels;
using AutoMapper;

namespace Asp.netcore_practice.Services
{
    public class ProducerService:IProducerService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProducerService(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddProducer(ProducerViewModel producer)
        {
            var _producer = new Producer()
            {
                
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

        public List<ProducerViewModel> GetAllProducers()
        {
            var producers = _context.Producers.Select(a=>_mapper.Map<Producer,ProducerViewModel>(a)).ToList();
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

        public ProducerViewModel Update(int id, ProducerViewModel producer)
        {
            var _producer = _context.Producers.FirstOrDefault(n => n.ProducerId == id);
            if (_producer != null)
            {
                _producer.ProfilePictureUrl = producer.ProfilePictureUrl;
                _producer.ProducerName = producer.ProducerName;
                _producer.Bio = producer.Bio;

                _context.SaveChanges();
            }
            return _mapper.Map<Producer,ProducerViewModel>(_producer);
        }
    }
}
