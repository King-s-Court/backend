namespace common.Models;

public class Player {
    public Guid PlayerId { get; set; }
    public string? QueueId { get; set; }
    public string PlayerName { get; set; }
    public string PlayerEmail { get; set; }
    public GameMode? GameMode { get; set; }
}