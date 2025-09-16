using CleanTeeth.Application.Notifications;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Infrastructure.Notifications
{
    public class EmailService : INotifications
    {
        private readonly IConfiguration configuration;

        public EmailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task SendAppointmentConfirmation(AppointmentConfirmationDTO appointmentConfirmationDTO)
        {
            var subject = "Appointment Confirmation - Clean Teeth";
            var body = $"""
                Dear, {appointmentConfirmationDTO.Patient},

                Your appointment with Dr. {appointmentConfirmationDTO.Dentist} has been scheduled for {appointmentConfirmationDTO.Date.ToString("f", new CultureInfo("es-DO"))} in the office {appointmentConfirmationDTO.DentalOffice}.

                We will be waiting for you.

                Clean Teeth team
                """;

            await SendEmail(appointmentConfirmationDTO.Patient_Email, subject, body);
        }

        public async Task SendAppointmentReminder(AppointmentReminderDTO appointmentReminderDTO)
        {
            var subject = "Appointment Reminder - Clean Teeth";
            var body = $"""
                Dear {appointmentReminderDTO.Patient},

                This is a reminder for your appointment with Dr. {appointmentReminderDTO.Dentist} on {appointmentReminderDTO.Date.ToString("f", new CultureInfo("es-DO"))} in the office {appointmentReminderDTO.DentalOffice}.

                We will be waiting for you.

                Clean Teeth team
                """;

            await SendEmail(appointmentReminderDTO.Patient_Email, subject, body);
        }

        private async Task SendEmail(string to, string subject, string body)
        {
            var from = configuration.GetValue<string>("EMAIL_CONFIGURATIONS:EMAIL");
            var password = configuration.GetValue<string>("EMAIL_CONFIGURATIONS:PASSWORD");
            var host = configuration.GetValue<string>("EMAIL_CONFIGURATIONS:HOST");
            var port = configuration.GetValue<int>("EMAIL_CONFIGURATIONS:PORT");

            var smtpClient = new SmtpClient(host, port);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(from, password);

            var message = new MailMessage(from!, to, subject, body);
            await smtpClient.SendMailAsync(message);
        }
    }
}
