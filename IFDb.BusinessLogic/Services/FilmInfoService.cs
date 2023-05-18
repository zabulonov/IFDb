using IFDb.Infrastructure;

namespace IFDb.BusinessLogic.Services;

public class FilmInfoService
{
    private readonly FilmDbContextFactory _factory;

    public FilmInfoService(FilmDbContextFactory factory)
    {
        _factory = factory;
    }
    
}