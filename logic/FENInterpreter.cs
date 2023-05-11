using common.models;
using System.Text.RegularExpressions;


namespace logic;

public class FENInterpreter
{
    public static bool IsValidFEN(string fen)
    {
        string[] fenParts = fen.Split(' ');

        if (fenParts.Length != 6)
        {
            return false;
        }

        string position = fenParts[0];
        string activeColor = fenParts[1];
        string castlingAvailability = fenParts[2];
        string enPassantTargetSquare = fenParts[3];
        string halfMoveClock = fenParts[4];
        string fullMoveNumber = fenParts[5];

        Regex positionPattern = new Regex(@"^([rnbqkpRNBQKP1-8]{1,8}\/){7}[rnbqkpRNBQKP1-8]{1,8}$");
        Regex activeColorPattern = new Regex("^[bw]$");
        Regex castlingAvailabilityPattern = new Regex(@"^((K?Q?k?q?)|-)$");
        Regex enPassantTargetSquarePattern = new Regex(@"^(((([a-h])(3|6))|-)$)");
        Regex halfMoveClockPattern = new Regex(@"^\d+$");
        Regex fullMoveNumberPattern = new Regex(@"^[1-9]\d*$");

        return positionPattern.IsMatch(position) &&
            activeColorPattern.IsMatch(activeColor) &&
            castlingAvailabilityPattern.IsMatch(castlingAvailability) &&
            enPassantTargetSquarePattern.IsMatch(enPassantTargetSquare) &&
            halfMoveClockPattern.IsMatch(halfMoveClock) &&
            fullMoveNumberPattern.IsMatch(fullMoveNumber);

    }

    /// <summary>
    /// Interprets FEN string and populates Board.Squares accordingly.
    /// <param name="FEN">
    ///  </param>
    /// </summary>

    public static void LoadBoardFromFEN(string FEN = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1")
    {
        if (IsValidFEN(FEN))
        {
            string BoardFromFen = FEN.Split(' ')[0];
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
    }

    /// <summary>
    /// Interprets FEN string and populates Board.ToMove, Board.CastlingRights and Board.EnPassant accordingly.
    /// <param name="FEN">
    ///  </param>
    /// </summary>

    public static void LoadGameDataFromFEN(string FEN = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1")
    {
        if (IsValidFEN(FEN))
        {
            Board.ToMove = FEN.Split(' ')[1];
            Board.CastlingRights = FEN.Split(' ')[2];
            Board.EnPassant = FEN.Split(' ')[3];
        }
    }
}