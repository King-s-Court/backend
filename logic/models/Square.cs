namespace common.models;

public class Square
{
    public Piece? SquarePiece { get; set; }

    public Square(Piece? piece = null)
    {
        SquarePiece = piece;
    }
}