using Asp.netcore_practice.Models;
using Asp.netcore_practice.ViewModels;

namespace Asp.netcore_practice.Services
{
    public interface IProducerService
    {
        ProducerGetByIdViewModel GetById(int id);
        void AddProducer(ProducerViewModel producer);

        List<Producer> GetAllProducers();

        void Delete(int id);

        Producer Update(int id, ProducerViewModel producer);
    }
}
