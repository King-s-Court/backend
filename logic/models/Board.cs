namespace common.models;

public static class Board
{
    public static Piece[] Squares;

    static Board()
    {
        Squares = new Piece[64];
    }
}