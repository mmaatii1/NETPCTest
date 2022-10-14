using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace NETPCTest.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyCors")]
    public abstract class BaseApiController : Controller
    {
        protected readonly IMediator _mediator;
        protected readonly IMapper _mapper;

        protected BaseApiController(IMediator mediator, IMapper mapper)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
    }
}
