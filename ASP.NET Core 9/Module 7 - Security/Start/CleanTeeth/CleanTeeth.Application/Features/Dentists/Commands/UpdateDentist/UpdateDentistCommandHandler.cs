using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Utilities;
using CleanTeeth.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.Dentists.Commands.UpdateDentist
{
    public class UpdateDentistCommandHandler : IRequestHandler<UpdateDentistCommand>
    {
        private readonly IDentistRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public UpdateDentistCommandHandler(IDentistRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateDentistCommand request)
        {
            var Dentist = await repository.GetById(request.Id);

            if (Dentist is null)
            {
                throw new NotFoundException();
            }

            Dentist.UpdateName(request.Name);
            var email = new Email(request.Email);
            Dentist.UpdateEmail(email);

            try
            {
                await repository.Update(Dentist);
                await unitOfWork.Commit();
            }
            catch (Exception)
            {
                await unitOfWork.Rollback();
                throw;
            }
        }
    }
}
