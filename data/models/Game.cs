namespace data.models;

public class Game
{
    public Guid Id { get; set; }
    public GameMode GameMode { get; set; }
    public User PlayerWhite { get; set; }
    public User PlayerBlack { get; set; }
    public List<Move> Moves { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public string Fen { get; set; }
}