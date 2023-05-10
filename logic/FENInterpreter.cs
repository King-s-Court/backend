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

    public static void LoadBoardFromFEN(string fen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1")
    {
        string[] fenParts = fen.Split(' ');
        if (fenParts.Length == 4)
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
        }
        else
        {
            Console.WriteLine("Invalid FEN code...");
        }
    }
    public static void LoadGameDataFromFEN(string fen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1")
    {
        Board.ToMove = fen.Split(' ')[1] == "w" ? PieceColor.White : PieceColor.Black;
        Board.CastlingRights = fen.Split(' ')[2];
        Board.EnPassant = fen.Split(' ')[3];
    }


}