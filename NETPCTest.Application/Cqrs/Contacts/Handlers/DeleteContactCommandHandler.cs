using AutoMapper;
using MediatR;
using NETPCTest.Application.Cqrs.Contacts.Commands;
using NETPCTest.Application.Cqrs.Contacts.Responses;
using NETPCTest.Core.Entities;
using NETPCTest.Core.Interfaces;

namespace NETPCTest.Application.Cqrs.Contacts.Handlers
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, ContactResponse>
    {
        private readonly IGenericRepository<Contact> _contactRepo;
        private readonly IMapper _mapper;

        public DeleteContactCommandHandler(IGenericRepository<Contact> repo, IMapper mapper)
        {
            _mapper = mapper;
            _contactRepo = repo;
        }

        public async Task<ContactResponse> Handle(DeleteContactCommand command, CancellationToken cancellationToken)
        {
            var contactToDelete = await _contactRepo.DeleteAsync(command.Id);
            return _mapper.Map<ContactResponse>(contactToDelete);
        }
    }
}
