using AutoMapper;
using MediatR;
using NETPCTest.Application.Cqrs.Contacts.Responses;
using NETPCTest.Core.Entities;
using NETPCTest.Core.Interfaces;
using NETPCTest.Application.Cqrs.Contacts.Queries;

namespace NETPCTest.Application.Cqrs.Contacts.Handlers
{
    public class GetAllContactsQueryHandler : IRequestHandler<GetAllContactsQuery, IEnumerable<ContactResponse>>
    {
        private readonly IGenericRepository<Contact> _contactRepo;
        private readonly IMapper _mapper;

        public GetAllContactsQueryHandler(IGenericRepository<Contact> repo,
            IMapper mapper)
        {
            _mapper = mapper;
            _contactRepo = repo;
        }

        public async Task<IEnumerable<ContactResponse>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
        {
            var contacts = _contactRepo.GetWithEntity(x=>x.Category,c=>c.SubCategory);
            return _mapper.Map<IEnumerable<ContactResponse>>(contacts);
        }
    }
}
