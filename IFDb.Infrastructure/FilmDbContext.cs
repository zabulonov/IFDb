using Core;
using Microsoft.EntityFrameworkCore;

namespace IFDb.Infrastructure;

public class FilmDbContext : DbContext
{
    public static string DefaultSchemaName = "Film";

    public FilmDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        modelBuilder.HasDefaultSchema(DefaultSchemaName);
    }

    public async Task AddUser(User user)
    {
        Add(user);
        await SaveChangesAsync();
    }

    public Task<User?> FindUser(long id)
    {
        return Set<User>().FirstOrDefaultAsync(x => x.Id == id);
    }

    public DbSet<User> Users { get; set; }



}