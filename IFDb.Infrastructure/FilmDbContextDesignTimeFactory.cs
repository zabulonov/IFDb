using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace IFDb.Infrastructure;

public class FilmDbContextDesignTimeFactory: IDesignTimeDbContextFactory<FilmDbContext>
{
    private const string DefaultConnectionString =
        "Host=127.0.0.1;Username=user;Password=1234;Database=film_db;Port=5432";

    public static DbContextOptions<FilmDbContext> GetSqlServerOptions(string? connectionString)
    {
        return new DbContextOptionsBuilder<FilmDbContext>()
            .UseNpgsql(connectionString ?? DefaultConnectionString,
                x => { x.MigrationsHistoryTable("__EFMigrationsHistory", FilmDbContext.DefaultSchemaName); })
            .Options;
    }


    public FilmDbContext CreateDbContext(string[] args)
    {
        return new FilmDbContext(GetSqlServerOptions(null));
    }
}