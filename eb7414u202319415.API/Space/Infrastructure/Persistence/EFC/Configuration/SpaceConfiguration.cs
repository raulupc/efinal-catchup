using eb7414u202319415.API.Space.Domain.Model.Aggregates;
using eb7414u202319415.API.Space.Domain.Model.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eb7414u202319415.API.Space.Infrastructure.Persistence.EFC.Configuration;

public class SpaceConfiguration : IEntityTypeConfiguration<eb7414u202319415.API.Space.Domain.Model.Aggregates.Space>
{
    public void Configure(EntityTypeBuilder<eb7414u202319415.API.Space.Domain.Model.Aggregates.Space> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Property(s => s.WorkSpaceId).IsRequired();
        builder.Property(s => s.Name).IsRequired().HasMaxLength(50);
        builder.Property(s => s.State).IsRequired();
        builder.Property(s => s.ColorTag).IsRequired();

        builder.HasData(
            new eb7414u202319415.API.Space.Domain.Model.Aggregates.Space(4, "school", EState.ACTIVE, "AABBCC") { Id = 1 },
            new eb7414u202319415.API.Space.Domain.Model.Aggregates.Space(3, "family", EState.INACTIVE, "A52019") { Id = 2 },
            new eb7414u202319415.API.Space.Domain.Model.Aggregates.Space(2, "friends", EState.ACTIVE, "00913F") { Id = 3 },
            new eb7414u202319415.API.Space.Domain.Model.Aggregates.Space(6, "sport", EState.ACTIVE, "F5F5DC") { Id = 4 }
        );
    }
}