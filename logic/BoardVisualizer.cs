using common.models;

namespace logic;

public static class BoardVisualizer
{
    public static void VisualizeBoard()
    {
        var Squares = Board.GetBoardSquares();
        for (int rank = 0; rank < 8; rank++)
        {
            for (int file = 0; file < 8; file++)
            {
                var piece = Squares[rank, file].SquarePiece;
                if (piece == null)
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write(piece.PieceColor == PieceColor.White ? "w" : "b");
                    Console.Write(piece.PieceType switch
                    {
                        PieceType.Juicer => "p",
                        PieceType.Knight => "n",
                        PieceType.Bishop => "b",
                        PieceType.Rook => "r",
                        PieceType.Queen => "q",
                        PieceType.King => "k",
                        _ => throw new ArgumentOutOfRangeException()
                    });
                }
            }
        }
    }
}