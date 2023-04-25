using common.models;
using Type = common.models.Type;

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
        {'k', new Piece(Type.King, Color.Black)},
        {'q', new Piece(Type.Queen, Color.Black)},
        {'r', new Piece(Type.Rook, Color.Black)},
        {'b', new Piece(Type.Bishop, Color.Black)},
        {'n', new Piece(Type.Knight, Color.Black)},
        {'p', new Piece(Type.Pawn, Color.Black)},
        {'K', new Piece(Type.King, Color.White)},
        {'Q', new Piece(Type.Queen, Color.White)},
        {'R', new Piece(Type.Rook, Color.White)},
        {'B', new Piece(Type.Bishop, Color.White)},
        {'N', new Piece(Type.Knight, Color.White)},
        {'P', new Piece(Type.Pawn, Color.White)}
    };

    public static void LoadPositionFromFEN(string fen)
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
                Board.Squares[rank * 8 + file] = _pieceFromChar[symbol];
            }
        }
    }
}