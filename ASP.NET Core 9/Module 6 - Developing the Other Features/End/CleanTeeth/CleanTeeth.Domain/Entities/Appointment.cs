using CleanTeeth.Domain.Enums;
using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Domain.Entities
{
    public class Appointment
    {
        public Guid Id { get; private set; }
        public Guid PatientId { get; private set; }
        public Guid DentistId { get; private set; }
        public Guid DentalOfficeId { get; private set; }
        public AppointmentStatus Status { get; private set; }
        public TimeInterval TimeInterval { get; private set; } = null!;
        public Patient? Patient { get; private set; }
        public Dentist? Dentist { get; private set; }
        public DentalOffice? DentalOffice { get; private set; }

        private Appointment() { }

        public Appointment(Guid patientId, Guid dentistId, Guid dentalOfficeId, TimeInterval timeInterval)
        {
            if (timeInterval.Start < DateTime.UtcNow)
            {
                throw new BusinessRuleException($"The start time cannot be in the past");
            }

            PatientId = patientId;
            DentistId = dentistId;
            DentalOfficeId = dentalOfficeId;
            TimeInterval = timeInterval;
            Status = AppointmentStatus.Scheduled;
            Id = Guid.CreateVersion7();

        }

        public void Cancel()
        {
            if (Status != AppointmentStatus.Scheduled)
            {
                throw new BusinessRuleException("Only scheduled appointments can be cancelled");
            }

            Status = AppointmentStatus.Cancelled;
        }

        public void Complete()
        {
            if (Status != AppointmentStatus.Scheduled)
            {
                throw new BusinessRuleException("Only scheduled appointments can be completed");
            }

            Status = AppointmentStatus.Completed;
        }
    }
}
