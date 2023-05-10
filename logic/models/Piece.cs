namespace common.models;
using static PieceType;
public abstract class Piece
{
    public abstract PieceColor PieceColor { get; set; }
    public abstract PieceType PieceType { get; set; }

    public Piece(PieceColor pieceColor, PieceType pieceType)
    {
        PieceColor = pieceColor;
        PieceType = pieceType;
    }

    public char AsFENChar()
    {
        return this.PieceColor == PieceColor.Black
            ? $"{this.PieceType}".ToLower()[0]
            : $"{this.PieceType}"[0];
    }
}