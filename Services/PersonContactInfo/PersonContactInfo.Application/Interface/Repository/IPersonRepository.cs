using UserContactInformation.Domain.Entities;

namespace UserContactInformation.Application.Interface.Repository
{
    public interface IPersonRepository
    {
        void Add(Person person);
        void Remove(Person person);
    }
}
