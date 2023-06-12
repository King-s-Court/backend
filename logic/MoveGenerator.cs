using common.models;
using common.models.pieces;

namespace logic;

public static class MoveGenerator
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
}