namespace common.models.pieces;

public class Rook : Piece
{
    
    public Rook(PieceColor pieceColor, PieceType pieceType) : base(pieceColor, pieceType)
    {
    }

    public override PieceColor PieceColor { get; set; }
    public override PieceType PieceType { get; set; }
}