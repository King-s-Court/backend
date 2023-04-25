namespace common.models.pieces;

public class Bishop : Piece
{
    public Bishop(PieceColor pieceColor, PieceType pieceType) : base(pieceColor, pieceType)

    {
}

    public override PieceColor PieceColor { get; set; }
    public override PieceType PieceType { get; set; }
}