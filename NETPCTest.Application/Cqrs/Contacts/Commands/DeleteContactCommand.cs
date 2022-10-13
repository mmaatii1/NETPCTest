using MediatR;
using NETPCTest.Application.Cqrs.Contacts.Responses;

namespace NETPCTest.Application.Cqrs.Contacts.Commands
{
    public record DeleteContactCommand(int Id) : IRequest<ContactResponse>
    {
    }
}
