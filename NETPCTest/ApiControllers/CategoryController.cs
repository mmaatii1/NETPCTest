using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NETPCTest.Application.Cqrs.Categories.Queries;
using NETPCTest.Application.Cqrs.SubCategories.Commands;
using NETPCTest.Application.Cqrs.SubCategories.Requests;

namespace NETPCTest.ApiControllers
{
    public class CategoryController : BaseApiController
    {
        public CategoryController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var query = new GetAllCategoriesQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}
