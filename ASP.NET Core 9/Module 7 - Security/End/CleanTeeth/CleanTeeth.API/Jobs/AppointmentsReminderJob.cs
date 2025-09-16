
using CleanTeeth.Application.Features.Appointments.Commands.SendAppointmentReminder;
using CleanTeeth.Application.Utilities;

namespace CleanTeeth.API.Jobs
{
    public class AppointmentsReminderJob : BackgroundService
    {
        private readonly IServiceScopeFactory serviceScope;
        private readonly TimeZoneInfo timeZoneEST = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

        public AppointmentsReminderJob(IServiceScopeFactory serviceScope)
        {
            this.serviceScope = serviceScope;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneEST);

                if (now.Hour == 8)
                {
                    using var scope = serviceScope.CreateScope();
                    var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                    await mediator.Send(new SendAppointmentReminderCommand());
                }

                await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
            }
        }
    }
}
