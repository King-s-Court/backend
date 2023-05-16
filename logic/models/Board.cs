namespace common.models;

public static class Board
{
    // [ranks, files]
    public static Square[,] Squares = new Square[8, 8];
    public static string ToMove { get; set; }
    public static string CastlingRights { get; set; }
    public static string EnPassant { get; set; }

    static Board()
    {
        ToMove = "w";
        CastlingRights = "KQkq";
        EnPassant = "-";
        for (int rank = 0; rank < 8; rank++)
        {
            for (int file = 0; file < 8; file++)
            {
                Squares[rank, file] = new Square();
            }
        }
    }

    public static Square[,] GetBoardSquares()
    {
        return Squares;
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