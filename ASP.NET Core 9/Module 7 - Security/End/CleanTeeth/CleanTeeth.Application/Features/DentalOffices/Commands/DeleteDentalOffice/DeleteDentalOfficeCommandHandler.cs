using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.DentalOffices.Commands.DeleteDentalOffice
{
    public class DeleteDentalOfficeCommandHandler : IRequestHandler<DeleteDentalOfficeCommand>
    {
        private readonly IDentalOfficeRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public DeleteDentalOfficeCommandHandler(IDentalOfficeRepository repository, 
            IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteDentalOfficeCommand request)
        {
            var dentalOffice = await repository.GetById(request.Id);

            if (dentalOffice is null)
            {
                throw new NotFoundException();
            }

            try
            {
                await repository.Delete(dentalOffice);
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
