using common.models;
using static System.Console;

namespace logic;

public class BoardVisualizer
{
    /// <summary>
    /// Reads data stored in _board.Squares and outputs them in CLI.
    /// <param name="FEN">
    ///  </param>
    /// </summary>
    public static void VisualizeBoardFromSquares(Board board)
    {
        Write("    0   1   2   3   4   5   6   7");
        for (int rank = 0; rank < 8; rank++)
        {
            Write("\n  ---------------------------------\n");
            for (int file = 0; file < 8; file++)
            {
                if (file == 0)
                {
                    Write($"{rank} |");
                }
                else
                {
                    Write("|");
                }
                if (!board.IsOccupied(rank, file))
                {
                    Write("   ");
                }
                else
                {
                    Write(" " + board.GetPiece(rank, file)?.AsFENChar() + " ");
                }
            }
            Write($"| {8 - rank}");
        }
        Write("\n  ---------------------------------");
        Write("\n    a   b   c   d   e   f   g   h \n\n");
        Write("Color to move: \n");
        Write(board.ToMove == "w" ? "White\n\n" : "Black\n\n");
        Write("Castling rights: \n");
        foreach (char symbol in board.CastlingRights)
        {
            Write(CastlingRightsDictionary._castlingRights[symbol] + '\n');
        }
        Write("\n");
        Write($"En passant target square: \n {board.EnPassant}\n");

    }

    public static void VisualizeBoardForSystemCoords()
    {
        for (int rank = 0; rank < 8; rank++)
        {
            Write("\n---------------------------------\n");
            for (int file = 0; file < 8; file++)
            {
                Write("|");
                Write($"{rank}:{file}");
            }
            Write($"| {8 - rank}");
        }
        Write("\n---------------------------------");
        Write("\n  a   b   c   d   e   f   g   h \n\n");
    }
}