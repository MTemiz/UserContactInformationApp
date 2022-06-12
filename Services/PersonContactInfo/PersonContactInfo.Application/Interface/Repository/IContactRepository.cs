using PersonContactInfo.Domain.Entities;

namespace PersonContactInfo.Application.Interface.Repository
{
    public interface IContactRepository
    {
        Task<Contact?> GetByIdAsync(Guid id);
        Task<List<Contact>> GetByPersonIdAsync(Guid personId);

        Task AddAsync(Contact contact);
        Task RemoveAsync(Contact contact);
        Task<List<Contact>> GetAllAsync();
    }
}
