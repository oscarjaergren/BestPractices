namespace Logging;

#pragma warning disable CS8618

public record SessionRecord
{
    public int Id { get; set; }

    public DateTime CreatedDateTime { get; set; } = DateTime.Now;

    public Guid UniqueId { get; set; }

    public string UserId { get; set; }

    public int OrganisationId { get; set; }

    public string Email { get; set; }

    public bool IsOnlineMode { get; set; }
}