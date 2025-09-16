using CleanTeeth.Application.Contracts.Repositories.Models;
using CleanTeeth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Contracts.Repositories
{
    public interface IAppointmentRepository: IRepository<Appointment>
    {
        Task<bool> OverlapExists(Guid dentistId, DateTime start, DateTime end);
        new Task<Appointment?> GetById(Guid id);
        Task<IEnumerable<Appointment>> GetFiltered(AppointmentsFilterDTO appointmentsFilterDTO);
    }
}
