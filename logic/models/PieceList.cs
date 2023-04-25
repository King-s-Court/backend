namespace common.models;

public class PieceList
{
    private int[] occupiedSquares;
    private int[] map;
    int numPieces;

    public PieceList(int maxPieceCount = 16)
    {
        occupiedSquares = new int[maxPieceCount];
        map = new int[64];
        numPieces = 0;
    }

    public int Count
    {
        get { return numPieces; }
    }

    //TODO: implement CRUD for PieceList
    
    public void AddPieceAtSquare(int square)
    {
    }

    public void RemovePieceAtSquare(int square)
    {
    }

    public void MovePiece(int startSquare, int targetSquare)
    {
    }
}