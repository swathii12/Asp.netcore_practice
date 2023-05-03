using Asp.netcore_practice.Models;
using Asp.netcore_practice.ViewModels;

namespace Asp.netcore_practice.Services
{
    public interface IProducerService
    {
        ProducerGetByIdViewModel GetById(int id);
        void AddProducer(ProducerViewModel producer);

        List<ProducerViewModel> GetAllProducers();

        void Delete(int id);

        ProducerViewModel Update(int id, ProducerViewModel producer);
    }
}
