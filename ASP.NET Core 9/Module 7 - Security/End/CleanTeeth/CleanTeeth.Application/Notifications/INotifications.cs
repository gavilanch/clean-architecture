using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Notifications
{
    public interface INotifications
    {
        Task SendAppointmentConfirmation(AppointmentConfirmationDTO appointmentConfirmationDTO);
        Task SendAppointmentReminder(AppointmentReminderDTO appointmentReminderDTO);
    }
}
