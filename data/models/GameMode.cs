namespace data.models;

public class GameMode
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public double TimeLimit { get; set; }
    public double Increment { get; set; }
}