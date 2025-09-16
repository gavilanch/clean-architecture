using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Features.Patients.Commands.CreatePatient;
using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.ValueObjects;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Tests.Application.Features.Patients
{
    [TestClass]
    public class CreatePatientCommandHandlerTests
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private IPatientRepository repository;
        private IUnitOfWork unitOfWork;
        private CreatePatientCommandHandler handler;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        [TestInitialize]
        public void Setup()
        {
            repository = Substitute.For<IPatientRepository>();
            unitOfWork = Substitute.For<IUnitOfWork>();
            handler = new CreatePatientCommandHandler(repository, unitOfWork);
        }


        [TestMethod]
        public async Task Handle_ValidCommand_ReturnsPatientId()
        {
            var command = new CreatePatientCommand { Name = "test", Email = "test@example.com" };
            var patient = new Patient(command.Name, new Email(command.Email));

            repository.Add(Arg.Any<Patient>()).Returns(patient);

            var result = await handler.Handle(command);

            Assert.AreEqual(patient.Id, result);
            await repository.Received(1).Add(Arg.Any<Patient>());
            await unitOfWork.Received(1).Commit();
        }

        [TestMethod]
        public async Task Handle_WhenTheresAnError_WeRollback()
        {
            var command = new CreatePatientCommand { Name = "test", Email = "test@example.com" };

            repository.Add(Arg.Any<Patient>()).Throws<Exception>();

            await Assert.ThrowsExceptionAsync<Exception>(async () =>
            {
                await handler.Handle(command);
            });

            await unitOfWork.Received(1).Rollback();

        }


    }
}
