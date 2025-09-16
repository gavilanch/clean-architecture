using CleanTeeth.API.DTOs.Appointments;
using CleanTeeth.Application.Features.Appointments.Commands.CancelAppointment;
using CleanTeeth.Application.Features.Appointments.Commands.CompleteAppointment;
using CleanTeeth.Application.Features.Appointments.Commands.CreateAppointment;
using CleanTeeth.Application.Features.Appointments.Queries.GetAppointmentDetail;
using CleanTeeth.Application.Features.Appointments.Queries.GetAppointmentsList;
using CleanTeeth.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace CleanTeeth.API.Controllers
{
    [ApiController]
    [Route("api/appointments")]
    public class AppointmentsController: ControllerBase
    {
        private readonly IMediator mediator;

        public AppointmentsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<AppointmentsListDTO>>> Get([FromQuery] GetAppointmentsListQuery query)
        {
            return await mediator.Send(query);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentDetailDTO>> Get(Guid id)
        {
            var query = new GetAppointmentDetailQuery { Id = id };
            return await mediator.Send(query);
        }


        [HttpPost]
        public async Task<IActionResult> Post(CreateAppointmentDTO createAppointmentDTO)
        {
            var command = new CreateAppointmentCommand
            {
                PatientId = createAppointmentDTO.PatientId,
                DentistId = createAppointmentDTO.DentistId,
                DentalOfficeId = createAppointmentDTO.DentalOfficeId,
                StartDate = createAppointmentDTO.StartDate,
                EndDate = createAppointmentDTO.EndDate
            };
            var result = await mediator.Send(command);
            return Ok();
        }

        [HttpPost("{id}/complete")]
        public async Task<IActionResult> Complete(Guid id)
        {
            var command = new CompleteAppointmentCommand { Id = id };
            await mediator.Send(command);
            return NoContent();
        }

        [HttpPost("{id}/cancel")]
        public async Task<IActionResult> Cancel(Guid id)
        {
            var command = new CancelAppointmentCommand { Id = id };
            await mediator.Send(command);
            return NoContent();
        }
    }
}
