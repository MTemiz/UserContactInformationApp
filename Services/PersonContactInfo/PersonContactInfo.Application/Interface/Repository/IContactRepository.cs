using UserContactInformation.Domain.Entities;

namespace UserContactInformation.Application.Interface.Repository
{
    public interface IContactRepository
    {
        void Add(Contact contact);
        void Remove(Contact contact);
    }
}
