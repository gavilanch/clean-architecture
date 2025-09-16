using CleanTeeth.API.DTOs.Patients;
using CleanTeeth.API.Utilities;
using CleanTeeth.Application.Features.Patients.Commands.CreatePatient;
using CleanTeeth.Application.Features.Patients.Commands.DeletePatient;
using CleanTeeth.Application.Features.Patients.Commands.UpdatePatient;
using CleanTeeth.Application.Features.Patients.Queries.GetPatientDetail;
using CleanTeeth.Application.Features.Patients.Queries.GetPatientsList;
using CleanTeeth.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace CleanTeeth.API.Controllers
{
    [ApiController]
    [Route("api/patients")]
    public class PatientsController : ControllerBase
    {
        private readonly IMediator mediator;

        public PatientsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<PatientListDTO>>> Get([FromQuery] GetPatientsListQuery query)
        {
            var result = await mediator.Send(query);
            HttpContext.InsertPaginationInformationInHeader(result.TotalAmountOfRecords);
            return result.Elements;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDetailDTO>> Get(Guid id)
        {
            var query = new GetPatientDetailQuery { Id = id };
            return await mediator.Send(query);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreatePatientDTO createPatientDTO)
        {
            var command = new CreatePatientCommand
            {
                Name = createPatientDTO.Name,
                Email = createPatientDTO.Email
            };

            await mediator.Send(command); 
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, UpdatePatientDTO updatePatientDTO)
        {
            var command = new UpdatePatientCommand
            {
                Id = id,
                Name = updatePatientDTO.Name,
                Email = updatePatientDTO.Email
            };
            await mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeletePatientCommand { Id = id };
            await mediator.Send(command);
            return NoContent();
        }
    }
}
