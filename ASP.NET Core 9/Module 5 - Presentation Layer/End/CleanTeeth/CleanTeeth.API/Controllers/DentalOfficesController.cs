using CleanTeeth.API.DTOs.DentalOffices;
using CleanTeeth.Application.Features.DentalOffices.Commands.CreateDentalOffice;
using CleanTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;
using CleanTeeth.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace CleanTeeth.API.Controllers
{
    [ApiController]
    [Route("api/dentaloffices")]
    public class DentalOfficesController: ControllerBase
    {
        private readonly IMediator mediator;

        public DentalOfficesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DentalOfficeDetailDTO>> Get(Guid id)
        {
            var query = new GetDentalOfficeDetailQuery { Id = id };
            var result = await mediator.Send(query);
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateDentalOfficeDTO createDentalOfficeDTO)
        {
            var command = new CreateDentalOfficeCommand { Name = createDentalOfficeDTO.Name };
            await mediator.Send(command);
            return Ok();
        }
    }
}
