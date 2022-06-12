using Moq;
using PersonContactInfo.Application.Interface.Repository;
using PersonContactInfo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonContactInfo.Application.Test.Mocks
{
    public static class MockPersonRepository
    {
        public static Mock<IPersonRepository> GetRepository()
        {
            var persons = new List<Person>()
            {
                new Person(){ Id = Guid.Parse("99c4a2ab-c8b9-4a69-bfeb-d08ccb26a2b7"),
                    Company="Google",
                    CreatedDate = DateTime.Now,
                    Name = "Nuri",
                    Surname="Demir"},

               new Person(){ Id = Guid.Parse("16214e38-dd59-4f91-ae40-677305257a16"),
                    Company="Bluemark",
                    CreatedDate = DateTime.Now,
                    Name = "Ayça",
                    Surname="Taşkıran"},

               new Person(){ Id = Guid.Parse("9fafd091-bb12-4d88-9631-76153fcce3a2"),
                    Company="Tesla",
                    CreatedDate = DateTime.Now,
                    Name = "Burak",
                    Surname="Karakılıç"}
            };

            var personsWithContact = new List<Person>()
            {
                new Person(){ Id = Guid.Parse("99c4a2ab-c8b9-4a69-bfeb-d08ccb26a2b7"),
                    Company="Google",
                    CreatedDate = DateTime.Now,
                    Name = "Nuri",
                    Surname="Demir",
                     Contacts = new List<Contact>()
                     {
                          new Contact(){ Id = Guid.Parse("adb086c6-7984-423f-a275-9b027e94f4e6"),
                           Email="nuri.demir@x.com",
                           Location="Ankara",
                           CreatedDate= DateTime.Now,
                           LastUpdatedDate=null,
                           PersonId =Guid.Parse("99c4a2ab-c8b9-4a69-bfeb-d08ccb26a2b7"),
                           Phone="05554443322"}
                     }
                },

               new Person(){ Id = Guid.Parse("16214e38-dd59-4f91-ae40-677305257a16"),
                    Company="Bluemark",
                    CreatedDate = DateTime.Now,
                    Name = "Ayça",
                    Surname="Taşkıran",
                    Contacts = new List<Contact>()
                     {
                          new Contact(){
                          Id = Guid.Parse("cae677ed-11e9-4c23-8bac-f1d6c597dd90"),
                           Email="ayca.taskiran@x.com",
                           Location="California",
                           CreatedDate= DateTime.Now,
                           LastUpdatedDate=null,
                           PersonId =Guid.Parse("16214e38-dd59-4f91-ae40-677305257a16"),
                           Phone="08887774455"}
                     }},

               new Person(){ Id = Guid.Parse("9fafd091-bb12-4d88-9631-76153fcce3a2"),
                    Company="Tesla",
                    CreatedDate = DateTime.Now,
                    Name = "Burak",
                    Surname="Karakılıç",
                    Contacts = new List<Contact>()
                     {
                          new Contact(){
                          Id = Guid.Parse("2c0c7155-709d-4e66-a4b9-8058ccf52f7c"),
                           Email="burak.karakilic@x.com",
                           Location="California",
                           CreatedDate= DateTime.Now,
                           LastUpdatedDate=null,
                           PersonId =Guid.Parse("9fafd091-bb12-4d88-9631-76153fcce3a2"),
                           Phone="09998887744"},
                          new Contact(){
                          Id = Guid.Parse("01bcd1e2-d745-4420-b74b-dbd427a1477e"),
                           Email="burak.karakilic@y.com",
                           Location="California",
                           CreatedDate= DateTime.Now,
                           LastUpdatedDate=null,
                           PersonId =Guid.Parse("9fafd091-bb12-4d88-9631-76153fcce3a2"),
                           Phone="05554443322"}
                     }}
            };

            var mockRepo = new Mock<IPersonRepository>();

            mockRepo.Setup(x => x.AddAsync(It.IsAny<Domain.Entities.Person>()))
             .Returns(new Func<Person, Task>(
                 person =>
                 {
                     persons.Add(person);
                     return Task.CompletedTask;
                 }));

            mockRepo.Setup(x => x.RemoveAsync(It.IsAny<Domain.Entities.Person>()))
             .Returns(new Func<Person, Task>(
              person =>
              {
                  persons.Remove(person);
                  return Task.CompletedTask;
              }));

            mockRepo.Setup(x => x.GetByIdWithContactsAsync(It.IsAny<Guid>()))
            .Returns(new Func<Guid, Task<Person?>>(
             guid =>
             {
                 return Task.FromResult(persons.FirstOrDefault(c => c.Id == guid));
             }));

            mockRepo.Setup(c => c.GetAllAsync()).Returns(Task.FromResult(persons.ToList()));

            return mockRepo;
        }
    }
}
