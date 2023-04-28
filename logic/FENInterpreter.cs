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
                Board.AddPiece(rank, file, PieceCharDictionary._pieceFromChar[symbol]);
                file++;
            }
        }
        
        BoardVisualizer.VisualizeBoard();
    }
}