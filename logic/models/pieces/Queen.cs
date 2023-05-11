namespace common.models.pieces;

public class Queen : Piece
{
    public Queen(PieceColor pieceColor, PieceType pieceType) : base(pieceColor, pieceType)
    {
    }

    public override PieceColor PieceColor { get; set; }
    public override PieceType PieceType { get; set; }
}