using eb7414u202319415.API.Folder.Domain.Model.Aggregates;
using eb7414u202319415.API.Folder.Domain.Model.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eb7414u202319415.API.Folder.Infrastructure.Persistence.EFC.Configuration;

public class FolderConfiguration : IEntityTypeConfiguration<eb7414u202319415.API.Folder.Domain.Model.Aggregates.Folder>
{
    public void Configure(EntityTypeBuilder<eb7414u202319415.API.Folder.Domain.Model.Aggregates.Folder> builder)
    {
        builder.ToTable("folders");

        builder.HasKey(f => f.Id);
        builder.Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        
        builder.Property(f => f.SpaceId).IsRequired();
        builder.Property(f => f.Name).IsRequired();
        builder.Property(f => f.Description).IsRequired();
        builder.Property(f => f.GeneratedAt).IsRequired();

        builder.Property(f => f.VisibilityType)
            .HasConversion<string>()
            .IsRequired();

        // AQUÍ ESTÁ LA CORRECCIÓN MÁGICA
        builder.OwnsOne(f => f.CreatedBy, cb =>
        {
            cb.WithOwner().HasForeignKey("Id"); // Esto fuerza a compartir el mismo ID 'id'
            cb.Property(p => p.Value)
                .HasColumnName("created_by")
                .IsRequired();
        });
    }
}