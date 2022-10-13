using AutoMapper;
using MediatR;
using NETPCTest.Application.Cqrs.Contacts.Commands;
using NETPCTest.Application.Cqrs.Contacts.Responses;
using NETPCTest.Core.Entities;
using NETPCTest.Core.Interfaces;

namespace NETPCTest.Application.Cqrs.Contacts.Handlers
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, ContactResponse>
    {
        private readonly IGenericRepository<Contact> _contactRepo;
        private readonly IMapper _mapper;

        public UpdateContactCommandHandler(IGenericRepository<Contact> repo, IMapper mapper)
        {
            _mapper = mapper;
            _contactRepo = repo;
        }

        public async Task<ContactResponse> Handle(UpdateContactCommand command, CancellationToken cancellationToken)
        {
            var contactToUpdate = _mapper.Map<Contact>(command);
            //validation for it is in repo implemntation 
            var updatedContact = await _contactRepo.UpdateAsync(contactToUpdate);
            return _mapper.Map<ContactResponse>(updatedContact);
        }
    }
}
