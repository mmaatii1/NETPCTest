using MediatR;
using NETPCTest.Application.Cqrs.SubCategories.Responses;

namespace NETPCTest.Application.Cqrs.SubCategories.Queries
{
    public record GetAllSubCategoriesQuery : IRequest<IEnumerable<SubCategoryResponse>>
    {
    }
}
