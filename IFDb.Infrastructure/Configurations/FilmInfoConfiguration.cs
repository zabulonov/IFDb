using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IFDb.Infrastructure.Configurations;

public class FilmInfoConfiguration : IEntityTypeConfiguration<FilmInfo>
{
    public void Configure(EntityTypeBuilder<FilmInfo> builder)
    {
        builder.ToTable(nameof(FilmInfo));
                
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        
        builder.Property(x => x.Title).IsRequired().HasMaxLength(90);
        builder.Property(x => x.Description).IsRequired().HasMaxLength(500);
        builder.Property(x => x.Year).IsRequired();
    }
}