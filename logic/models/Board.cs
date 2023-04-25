namespace common.models;

public static class Board
{
    // [ranks, files]
    public static readonly Square[,] Squares = new Square[8, 8];

    static Board()
    {
        for (int rank = 0; rank < 8; rank++)
        {
            for (int file = 0; file < 8; file++)
            {
                Squares[rank, file] = new Square();
            }
        }
    }

    public static void AddPiece(int rank, int file, Piece piece)
    {
        Squares[rank, file].SquarePiece = piece;
    }

    public static Piece GetPiece(int rank, int file)
    {
        return Squares[rank, file].SquarePiece;
    }

    public static bool HasPiece(int rank, int file, Piece piece)
    {
        return Squares[rank, file].SquarePiece == piece;
    }
}