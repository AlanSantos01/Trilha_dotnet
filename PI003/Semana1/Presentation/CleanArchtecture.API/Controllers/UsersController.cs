using Microsoft.AspNetCore.Mvc;
using MediatR;
using CleanArchitecture.Application.UseCases.CreateUser;


using CleanArchitecture.Application.UseCases.GetAllUser;

namespace CleanArchtecture.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<GetAllUserResponse>>> GetAll(CancellationToken cancellationToken)
        {
           var response = await _mediator.Send(new GetAllUserResponse(), cancellationToken);
           return Ok(response);
        }


        
        [HttpPost] 
        public async Task<ActionResult<CreateUserResponse>> Create(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateUserValidator();
            var validationResult = await validator.ValidateAsync(request);
            
            if (validationResult.IsValid){
                return BadRequest(validationResult.Errors);
            }

            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
