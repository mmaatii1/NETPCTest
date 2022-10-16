using MediatR;
using NETPCTest.Application.Cqrs.Categories.Responses;
using NETPCTest.Application.Cqrs.Contacts.Responses;

namespace NETPCTest.Application.Cqrs.Contacts.Queries
{
    public record GetAllContactsQuery : IRequest<IEnumerable<ContactResponse>>;
    
}
