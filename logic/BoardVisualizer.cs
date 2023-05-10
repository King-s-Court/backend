using common.models;
using common.models.pieces;
using static System.Console;

namespace logic;

public static class BoardVisualizer
{
    public static void VisualizeBoardFromFEN()
    {
        for (int rank = 0; rank < 8; rank++)
        {
            Write("\n---------------------------------\n");
            for (int file = 0; file < 8; file++)
            {
                Write("|");
                if (Board.Squares[rank, file].SquarePiece == null)
                {
                    Write("   ");
                }
                else
                {
                    Write(" " + Board.Squares[rank, file].SquarePiece.AsFENChar() + " ");
                }
            }
            Write($"| {8 - rank}");
        }
        Write("\n---------------------------------");
        Write("\n  a   b   c   d   e   f   g   h \n\n");
        Write("Color to move: ");
        Write(Board.ToMove == PieceColor.White ? "White\n" : "Black\n");
        Write("Castling rights: \n");
        foreach (char symbol in Board.CastlingRights)
        {
            Write(CastlignRightsDictionary._castlingRights[symbol]+ '\n');
        }
    }
}