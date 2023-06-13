using common.models;
using common.models.pieces;

namespace logic;

public class MoveGenerator
{
    public static void MakeMove(int startRank, int startFile, int targetRank, int targetFile, Board board)
    {
        if (board.IsOccupied(startRank, startFile))
        {
            board.MovePiece(startRank, startFile, targetRank, targetFile);
        }
        else
        {
            throw new InvalidOperationException("Empty square.");
        }
    }
    public string GenerateMove(string fen)
    {
        string newFen = "rnbqkbnr/pppp1ppp/8/4p3/4P3/8/PPPP1PPP/RNBQKBNR w KQkq - 0 2";
        return newFen;
    }
}