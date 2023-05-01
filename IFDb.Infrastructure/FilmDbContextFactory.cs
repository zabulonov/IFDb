namespace IFDb.Infrastructure;

public class FilmDbContextFactory
{
    private readonly string _connectionString;

    public FilmDbContextFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public FilmDbContext GetContext()
    {
        return new FilmDbContext(FilmDbContextDesignTimeFactory.GetSqlServerOptions(_connectionString));
    }
}