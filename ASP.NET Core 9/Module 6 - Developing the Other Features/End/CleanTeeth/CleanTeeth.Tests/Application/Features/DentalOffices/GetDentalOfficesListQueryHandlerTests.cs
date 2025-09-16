using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficesList;
using CleanTeeth.Domain.Entities;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Tests.Application.Features.DentalOffices
{
    [TestClass]
    public class GetDentalOfficesListQueryHandlerTests
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private IDentalOfficeRepository repository;
        private GetDentalOfficesListQueryHandler handler;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.


        [TestInitialize]
        public void Setup()
        {
            repository = Substitute.For<IDentalOfficeRepository>();
            handler = new GetDentalOfficesListQueryHandler(repository);
        }

        [TestMethod]
        public async Task Handle_WhenThereAreDentalOffices_ReturnsListOfThem()
        {
            var dentalOffices = new List<DentalOffice>
            {
                new DentalOffice("Dental Office A"),
                new DentalOffice("Dental Office B")
            };

            repository.GetAll().Returns(dentalOffices);

            var expected = dentalOffices.Select(d => new DentalOfficesListDTO
            {
                Id = d.Id,
                Name = d.Name
            }).ToList();

            var result = await handler.Handle(new GetDentalOfficesListQuery());

            Assert.AreEqual(expected.Count, result.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].Name, result[i].Name);
            }
        }

        [TestMethod]
        public async Task Handle_WhenThereAreNoDentalOffices_ItReturnsAnEmptyList()
        {
            repository.GetAll().Returns(new List<DentalOffice>());

            var result = await handler.Handle(new GetDentalOfficesListQuery());

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

    }
}
