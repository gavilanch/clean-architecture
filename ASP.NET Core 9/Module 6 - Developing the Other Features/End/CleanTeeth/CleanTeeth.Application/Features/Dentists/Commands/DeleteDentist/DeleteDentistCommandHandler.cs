using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.Dentists.Commands.DeleteDentist
{
    public class DeleteDentistCommandHandler : IRequestHandler<DeleteDentistCommand>
    {
        private readonly IDentistRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public DeleteDentistCommandHandler(IDentistRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteDentistCommand request)
        {
            var Dentist = await repository.GetById(request.Id);

            if (Dentist is null)
            {
                throw new NotFoundException();
            }

            try
            {
                await repository.Delete(Dentist);
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
