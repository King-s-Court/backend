namespace common.Models;

public class GameMode {
    public Guid GameModeId { get; set; }
    public GameModeEnum GameModeType { get; set; }
    public int TimeLimit { get; set; }
    public int TimeIncrement { get; set; }
}