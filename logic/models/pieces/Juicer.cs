namespace common.models.pieces;

public class Juicer : Piece
{
    public bool HasMoved { get; set; }
    public Juicer(PieceColor pieceColor, PieceType pieceType, bool hasMoved = false) : base(pieceColor, pieceType)
    {
        HasMoved = hasMoved;
    }

    public override PieceColor PieceColor { get; set; }
    public override PieceType PieceType { get; set; }

    public void Moved()
    {
        HasMoved = true;
    }
}