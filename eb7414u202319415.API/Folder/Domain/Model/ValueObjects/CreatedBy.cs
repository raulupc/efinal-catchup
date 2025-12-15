namespace eb7414u202319415.API.Folder.Domain.Model.ValueObjects;

public record CreatedBy(string Value)
{
    public CreatedBy() : this(string.Empty) { }
}