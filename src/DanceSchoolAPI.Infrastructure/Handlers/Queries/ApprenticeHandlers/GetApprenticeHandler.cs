using System;
using DanceSchoolAPI.Common.CQRSElements.Queries.CRUDQueries;
using DanceSchoolAPI.Common.CQRSElements.Queries.Interfaces;
using DanceSchoolAPI.Common.Models.Apprentice;
using DanceSchoolAPI.Infrastructure.Services;

namespace DanceSchoolAPI.Infrastructure.Handlers.Queries.ApprenticeHandlers;

public class GetApprenticeHandler : IQueryHandler<GetQuery<Apprentice>, Apprentice>
{
    private IApprenticeService apprenticeService;
    public GetApprenticeHandler(IApprenticeService apprenticeService)
    {
        this.apprenticeService = apprenticeService;
    }

    public async Task<Apprentice> HandleAsync(GetQuery<Apprentice> query)
        => await apprenticeService.GetAsync(query.Id);
}