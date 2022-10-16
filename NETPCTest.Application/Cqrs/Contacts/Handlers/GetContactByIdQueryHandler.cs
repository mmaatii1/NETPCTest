using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NETPCTest.Application.Cqrs.Contacts.Queries;
using NETPCTest.Application.Cqrs.Contacts.Responses;
using NETPCTest.Core.Entities;
using NETPCTest.Core.Interfaces;

namespace NETPCTest.Application.Cqrs.Contacts.Handlers
{
    internal class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, ContactResponse>
    {
        private readonly IGenericRepository<Contact> _contactRepo;
        private readonly IMapper _mapper;

        public GetContactByIdQueryHandler(IGenericRepository<Contact> repo,
            IMapper mapper)
        {
            _mapper = mapper;
            _contactRepo = repo;
        }

        public async Task<ContactResponse> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var contacts = _contactRepo.GetWithEntity(c => c.Category, c => c.SubCategory);
            var contact = await contacts.FirstOrDefaultAsync(x => x.Id == request.Id);
            return _mapper.Map<ContactResponse>(contact);
        }
    }
}
