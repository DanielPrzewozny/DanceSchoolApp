using System;
using DanceSchoolAPI.Common.CQRSElements.Queries.CRUDQueries;
using DanceSchoolAPI.Common.CQRSElements.Queries.Interfaces;
using DanceSchoolAPI.Common.Models.Apprentice;
using DanceSchoolAPI.Infrastructure.Services;

namespace DanceSchoolAPI.Infrastructure.Handlers.ApprenticeHandlers;

public class BrowseApprenticeHandler : IQueryHandler<BrowseQuery<Apprentice>, IEnumerable<Apprentice>>
{
    private IApprenticeService apprenticeService;
    public BrowseApprenticeHandler(IApprenticeService apprenticeService)
    {
        this.apprenticeService = apprenticeService;
    }

    public async Task<IEnumerable<Apprentice>> HandleAsync(BrowseQuery<Apprentice> query)
        => await apprenticeService.BrowseAsync();
}