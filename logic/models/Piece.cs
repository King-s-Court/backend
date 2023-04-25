namespace common.models;

public abstract class Piece
{
    public abstract PieceColor PieceColor { get; set; }
    public abstract PieceType PieceType { get; set; }

    public Piece(PieceColor pieceColor, PieceType pieceType)
    {
        PieceColor = pieceColor;
        PieceType = pieceType;
    }
}