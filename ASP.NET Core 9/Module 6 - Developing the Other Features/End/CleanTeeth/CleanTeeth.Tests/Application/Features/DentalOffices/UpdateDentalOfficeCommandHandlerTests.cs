using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Features.DentalOffices.Commands.UpdateDentalOffice;
using CleanTeeth.Domain.Entities;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Tests.Application.Features.DentalOffices
{
    [TestClass]
    public class UpdateDentalOfficeCommandHandlerTests
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private IDentalOfficeRepository repository;
        private IUnitOfWork unitOfWork;
        private UpdateDentalOfficeCommandHandler handler;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        [TestInitialize]
        public void Setup()
        {
            repository = Substitute.For<IDentalOfficeRepository>();
            unitOfWork = Substitute.For<IUnitOfWork>();
            handler = new UpdateDentalOfficeCommandHandler(repository, unitOfWork);
        }

        [TestMethod]
        public async Task Handle_WhenDentalOfficeExists_EntityIsUpdatedAndPersisted()
        {
            var dentalOffice = new DentalOffice("Dental Office A");
            var id = dentalOffice.Id;
            var command = new UpdateDentalOfficeCommand { Id = id, Name = "New name" };

            repository.GetById(id).Returns(dentalOffice);

            await handler.Handle(command);

            await repository.Received(1).Update(dentalOffice);
            await unitOfWork.Received(1).Commit();
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public async Task Handle_WhenDentalOfficeDoNotExists_Throws()
        {
            var command = new UpdateDentalOfficeCommand { Id = Guid.NewGuid(), Name = "New name" };
            repository.GetById(command.Id).ReturnsNull();
            await handler.Handle(command);
        }

        [TestMethod]
        public async Task Handle_WhenThereIsAnExceptionUpdating_RollbackIsCalled()
        {
            var dentalOffice = new DentalOffice("Dental Office 1");
            var id = dentalOffice.Id;
            var command = new UpdateDentalOfficeCommand { Id = id, Name = "New name" };

            repository.GetById(id).Returns(dentalOffice);
            repository.Update(dentalOffice).Throws(new InvalidOperationException("Exception"));

            await Assert.ThrowsExceptionAsync<InvalidOperationException>(() => handler.Handle(command));

            await unitOfWork.Received(1).Rollback();
        }
    }
}
