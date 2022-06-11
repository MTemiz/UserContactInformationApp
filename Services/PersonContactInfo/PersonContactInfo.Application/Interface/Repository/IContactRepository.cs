using UserContactInformation.Domain.Entities;

namespace UserContactInformation.Application.Interface.Repository
{
    public interface IContactRepository
    {
        Contact? GetById(Guid id);
        List<Contact> GetByPersonId(Guid personId);

        Task<int> AddAsync(Contact contact);
        Task<int> RemoveAsync(Contact contact);
        IQueryable<Contact> GetAll();
    }
}
