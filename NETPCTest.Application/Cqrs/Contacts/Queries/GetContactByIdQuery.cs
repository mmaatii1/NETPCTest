using MediatR;
using NETPCTest.Application.Cqrs.Contacts.Responses;

namespace NETPCTest.Application.Cqrs.Contacts.Queries
{
    public record GetContactByIdQuery(int Id) : IRequest<ContactResponse>
    {
    }
}
