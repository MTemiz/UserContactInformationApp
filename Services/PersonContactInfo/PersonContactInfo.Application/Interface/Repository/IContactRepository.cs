using PersonContactInfo.Domain.Entities;

namespace PersonContactInfo.Application.Interface.Repository
{
    public interface IContactRepository
    {
        Task<Contact?> GetByIdAsync(Guid id);
        Task<List<Contact>> GetByPersonIdAsync(Guid personId);

        Task<int> AddAsync(Contact contact);
        Task<int> RemoveAsync(Contact contact);
        IQueryable<Contact> GetAll();
    }
}
