using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Features.Patients.Queries.GetPatientsList;
using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.ValueObjects;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Tests.Application.Features.Patients
{
    [TestClass]
    public class GetPatientsListQueryHandlerTests
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private IPatientRepository repository;
        private GetPatientsListQueryHandler handler;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        [TestInitialize]
        public void Setup()
        {
            repository = Substitute.For<IPatientRepository>();
            handler = new GetPatientsListQueryHandler(repository);
        }

        [TestMethod]
        public async Task Handle_ValidQuery_ReturnsPatientsPaginated()
        {
            var page = 1;
            var recordsPerPage = 2;

            var patient1 = new Patient("Patient 1", new Email("patient1@example.com"));
            var patient2 = new Patient("Patient 2", new Email("patient2@example.com"));

            IEnumerable<Patient> patients = new List<Patient> { patient1, patient2 };

            repository.GetFiltered(Arg.Any<PatientsFilterDTO>()).Returns(Task.FromResult(patients));

            repository.GetTotalAmountOfRecords().Returns(Task.FromResult(10));

            var query = new GetPatientsListQuery { Page = page, RecordsPerPage = recordsPerPage };

            var result = await handler.Handle(query);


            Assert.AreEqual(10, result.TotalAmountOfRecords);
            Assert.AreEqual(2, result.Elements.Count);

        }

        [TestMethod]
        public async Task Handle_WhenThereAreNoPatients_ReturnsEmptyListAndZero()
        {
            IEnumerable<Patient> patients = new List<Patient>();

            repository.GetFiltered(Arg.Any<PatientsFilterDTO>()).Returns(Task.FromResult(patients));

            repository.GetTotalAmountOfRecords().Returns(Task.FromResult(0));

            var query = new GetPatientsListQuery { Page = 1, RecordsPerPage = 5 };

            var result = await handler.Handle(query);

            Assert.AreEqual(0, result.TotalAmountOfRecords);
            Assert.IsNotNull(result.Elements);
            Assert.AreEqual(0, result.Elements.Count);
        }

    }
}
