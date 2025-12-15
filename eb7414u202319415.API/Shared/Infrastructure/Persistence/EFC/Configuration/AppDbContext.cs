using eb7414u202319415.API.Folder.Infrastructure.Persistence.EFC.Configuration;
using eb7414u202319415.API.Shared.Infrastructure.Persistence.EFC.Extensions;
using eb7414u202319415.API.Space.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace eb7414u202319415.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.ApplyConfiguration(new SpaceConfiguration());
        builder.ApplyConfiguration(new FolderConfiguration());

        builder.UseSnakeCaseNamingConvention();
    }
}