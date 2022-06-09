using UserContactInformation.Application.Interface.Context;
using UserContactInformation.Application.Interface.Repository;
using UserContactInformation.Domain.Entities;

namespace UserContactInformation.Inftastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IApplicationDbContext context;

        public PersonRepository(IApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(Person person)
        {
            context.Persons.Add(person);
            context.SaveChanges();
        }

        public void Remove(Person person)
        {
            context.Persons.Remove(person);
            context.SaveChanges();
        }
    }
}
