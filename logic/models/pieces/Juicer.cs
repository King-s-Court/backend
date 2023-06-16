namespace common.models.pieces;

public class Juicer : Piece
{
    public bool HasMoved { get; set; }
    public Juicer(PieceColor pieceColor, PieceType pieceType) : base(pieceColor, pieceType)
    {
        HasMoved = false;
    }
    public override PieceColor PieceColor { get; set; }
    public override PieceType PieceType { get; set; }
}