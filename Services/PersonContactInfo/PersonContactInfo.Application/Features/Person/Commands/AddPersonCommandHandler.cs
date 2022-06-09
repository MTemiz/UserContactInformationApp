﻿using MediatR;
using UserContactInformation.Application.Features.Person.Dtos;
using UserContactInformation.Application.Interface.Repository;

namespace UserContactInformation.Application.Features.Person.Commands
{
    public class AddPersonCommandHandler : IRequestHandler<AddPersonCommand, PersonDto>
    {
        private readonly IPersonRepository personRepository;

        public AddPersonCommandHandler(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        public Task<PersonDto> Handle(AddPersonCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
