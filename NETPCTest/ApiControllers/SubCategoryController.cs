using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NETPCTest.Application.Cqrs.SubCategories.Commands;
using NETPCTest.Application.Cqrs.SubCategories.Queries;
using NETPCTest.Application.Cqrs.SubCategories.Requests;

namespace NETPCTest.ApiControllers
{
    public class SubCategoryController : BaseApiController
    {
        public SubCategoryController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubCategories()
        {
            var query = new GetAllSubCategoriesQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSubCategory([FromBody] CreateSubCategoryRequest request)
        {
            var command = _mapper.Map<CreateSubCategoryCommand>(request);
            var response = await _mediator.Send(command);
            return CreatedAtAction(nameof(CreateSubCategory), new { id = response.Id }, response);
        }
    }
}
