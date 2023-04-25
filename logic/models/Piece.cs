namespace common.models;

public class Piece
{
    public Type Type { get; set; }
    
    public Color Color { get; set; }
    
    public Piece(Type type, Color color)
    {
        Type = type;
        Color = color;
    }
}