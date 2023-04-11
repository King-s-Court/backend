public abstract class GameMode {
    public Guid GameModeId { get; set; }
    public String Name { get; set; }
    public int TimeLimit { get; set; }
    public int TimeIncrement { get; set; }
}