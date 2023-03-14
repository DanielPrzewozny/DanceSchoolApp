using DanceSchoolAPI.Common.CQRSElements.Queries.CRUDQueries;
using DanceSchoolAPI.Common.CQRSElements.Queries.Interfaces;
using DanceSchoolAPI.Common.Models.Apprentice;
using DanceSchoolAPI.Infrastructure.Services;

namespace DanceSchoolAPI.Infrastructure.Handlers.ApprenticeHandlers;

public class CreateApprenticeHandler : IQueryHandler<CreateQuery<Apprentice>, long>
{
    private IApprenticeService apprenticeService;

    public CreateApprenticeHandler(IApprenticeService apprenticeService)
    {
        this.apprenticeService = apprenticeService;
    }

    public async Task<long> HandleAsync(CreateQuery<Apprentice> command) => await apprenticeService.CreateAsync(command.Value);
}