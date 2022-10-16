using System.Runtime.CompilerServices;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NETPCTest.Application.Cqrs.Contacts.Commands;
using NETPCTest.Application.Cqrs.Contacts.Queries;
using NETPCTest.Application.Cqrs.Contacts.Requests;

namespace NETPCTest.ApiControllers
{
    /// <summary>
    /// thanks to mediatR, pipeline and baseApiController
    /// controllers are small and cohesive which is good, also
    /// SRP 
    /// </summary>
    public class ContactController : BaseApiController
    {
        public ContactController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContacts()
        {
            var query = new GetAllContactsQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById([FromRoute] int id)
        {
            var query = new GetContactByIdQuery(id);
            var response = await _mediator.Send(query);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] CreateContactRequest request)
        {
            var command = _mapper.Map<CreateContactCommand>(request);
            var response = await _mediator.Send(command);
            return CreatedAtAction(nameof(CreateContact), new { id = response.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact([FromBody] UpdateContactRequest request, [FromRoute] int id)
        {
            var command = _mapper.Map<UpdateContactCommand>(request);
            command.Id = id;
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact([FromRoute] int id)
        {
            var command = new DeleteContactCommand(id);
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
