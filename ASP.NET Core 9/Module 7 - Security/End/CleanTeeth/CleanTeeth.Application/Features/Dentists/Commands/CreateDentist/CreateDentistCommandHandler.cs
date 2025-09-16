using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Utilities;
using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.Dentists.Commands.CreateDentist
{
    public class CreateDentistCommandHandler : IRequestHandler<CreateDentistCommand, Guid>
    {
        private readonly IDentistRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public CreateDentistCommandHandler(IDentistRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateDentistCommand request)
        {
            var email = new Email(request.Email);
            var dentist = new Dentist(request.Name, email);

            try
            {
                var result = await repository.Add(dentist);
                await unitOfWork.Commit();
                return result.Id;
            }
            catch (Exception)
            {
                await unitOfWork.Rollback();
                throw;
            }
        }
    }
}
