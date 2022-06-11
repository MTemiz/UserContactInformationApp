using UserContactInformation.Domain.Entities;

namespace UserContactInformation.Application.Interface.Repository
{
    public interface IPersonRepository
    {
        Task<int> AddAsync(Person person);
        Task<int> RemoveAsync(Person person);

        Person? GetByIdWithContacts(Guid id);

        List<Person> GetAllWithContacts();
    }
}
