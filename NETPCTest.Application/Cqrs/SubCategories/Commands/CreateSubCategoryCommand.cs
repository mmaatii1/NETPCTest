using MediatR;
using NETPCTest.Application.Cqrs.SubCategories.Responses;

namespace NETPCTest.Application.Cqrs.SubCategories.Commands
{
    public record CreateSubCategoryCommand(string SubCategoryName) : IRequest<SubCategoryResponse>;

    
}
