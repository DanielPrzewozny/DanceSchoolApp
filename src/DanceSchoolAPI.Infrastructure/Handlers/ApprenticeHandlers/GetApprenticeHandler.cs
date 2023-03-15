using DanceSchoolAPI.Common.CQRSElements.Queries.CRUDQueries;
using DanceSchoolAPI.Common.CQRSElements.Queries.Interfaces;
using DanceSchoolAPI.Common.Models.Apprentice;
using DanceSchoolAPI.Infrastructure.Services.Interfaces;

namespace DanceSchoolAPI.Infrastructure.Handlers.ApprenticeHandlers;

public class GetApprenticeHandler : IQueryHandler<GetQuery<Apprentice>, Apprentice>
{
    private IApprenticeService apprenticeService;

    public GetApprenticeHandler(IApprenticeService apprenticeService)
    {
        this.apprenticeService = apprenticeService;
    }

    public async Task<Apprentice> HandleAsync(GetQuery<Apprentice> command)
        => await apprenticeService.GetAsync(command.Id);
}