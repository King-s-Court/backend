using common.models;

namespace logic;

public static class MoveGenerator
{
    public static void MakeMove(int startRank, int startFile, int targetRank, int targetFile, Board board)
    {
        if (board.IsOccupied(startRank, startFile) && MoveValidator.IsValid(board, startRank, startFile, targetRank, targetFile))
        {
            board.MovePiece(startRank, startFile, targetRank, targetFile);
        }
        else
        {
            throw new InvalidOperationException("Empty square.");
        }
    }
    public static string GenerateMove(string fen)
    {
        string newFen = "rnbqkbnr/pppp1ppp/8/4p3/4P3/8/PPPP1PPP/RNBQKBNR w KQkq - 0 2";
        return newFen;
    }
}