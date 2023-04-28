using common.models.pieces;
namespace common.models;

public static class PieceCharDictionary
{
    public static readonly Dictionary<char, Piece> _pieceFromChar = new()
    {
        {'k', new King(PieceColor.Black, PieceType.King)},
        {'q', new Queen(PieceColor.Black, PieceType.Queen)},
        {'r', new Rook(PieceColor.Black, PieceType.Rook)},
        {'b', new Bishop(PieceColor.Black, PieceType.Bishop)},
        {'n', new Knight(PieceColor.Black, PieceType.Knight)},
        {'p', new Juicer(PieceColor.Black, PieceType.Juicer)},
        {'K', new King(PieceColor.White, PieceType.King)},
        {'Q', new Queen(PieceColor.White, PieceType.Queen)},
        {'R', new Rook(PieceColor.White, PieceType.Rook)},
        {'B', new Bishop(PieceColor.White, PieceType.Bishop)},
        {'N', new Knight(PieceColor.White, PieceType.Knight)},
        {'P', new Juicer(PieceColor.White, PieceType.Juicer)}
    };
}