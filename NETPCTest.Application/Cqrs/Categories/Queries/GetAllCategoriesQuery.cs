using MediatR;
using NETPCTest.Application.Cqrs.Categories.Responses;

namespace NETPCTest.Application.Cqrs.Categories.Queries
{
    public record GetAllCategoriesQuery : IRequest<IEnumerable<CategoryResponse>>
    {
    }
}
