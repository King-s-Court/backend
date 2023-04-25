using common.models;
using common.models.pieces;

namespace logic;

public class FENInterpreter
{
    /// <summary>
    /// Loads a position from a FEN string.
    /// <param name="fen">
    /// rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1
    /// </param>
    /// </summary>
    
    private static readonly Dictionary<char, Piece> _pieceFromChar = new()
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

    public static void LoadPositionFromFEN(string fen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1")
    {
        string BoardFromFen = fen.Split(' ')[0];
        int rank = 0, file = 0;

        foreach (char symbol in BoardFromFen)
        {
            if (symbol == '/')
            {
                file = 0;
                rank++;
            }
            else if (char.IsDigit(symbol))
            {
                file += int.Parse(symbol.ToString());
            }
            else
            {
                Board.AddPiece(rank, file, _pieceFromChar[symbol]);
                file++;
            }
        }
    }
}