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
        if (this.PieceColor == PieceColor.White)
        {
            return this.PieceType switch
            {
                PieceType.Juicer => 'J',
                PieceType.Rook => 'R',
                PieceType.Knight => 'N',
                PieceType.Bishop => 'B',
                PieceType.Queen => 'Q',
                PieceType.King => 'K',
                _ => ' '
            };
        }
        else if (this.PieceColor == PieceColor.Black)
        {
            return this.PieceType switch
            {
                PieceType.Juicer => 'j',
                PieceType.Rook => 'r',
                PieceType.Knight => 'n',
                PieceType.Bishop => 'b',
                PieceType.Queen => 'q',
                PieceType.King => 'k',
                _ => ' '
            };
        }
        return ' ';
    }
}