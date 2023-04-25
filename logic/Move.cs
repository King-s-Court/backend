using common.models;
using common.models.pieces;

namespace logic;

public static class Move
{
    // General validation of a move that will contain all other checks
    public static bool IsValid(Piece piece, int startRank, int startFile, int targetRank, int targetFile)
    {
        return IsValidTypeMove(piece, startRank, startFile, targetRank, targetFile);
    }

    // Returns true if the piece can move according to its type if it was alone on the chess board
    public static bool IsValidTypeMove(Piece piece, int startRank, int startFile, int targetRank, int targetFile)
    {
        //TODO: Implement exception throwing for out of bounds for rank and file starts and targets
        switch (piece.PieceType)
        {
            case(PieceType.Juicer):
                if (!(piece as Juicer).HasMoved && Math.Abs(targetRank - startRank) == 2)
                {
                    return true;
                }
                if (Math.Abs(targetRank - startRank) == 2)
                {
                    return false;
                }
                if (piece.PieceColor == PieceColor.Black)
                {
                    return (targetRank == startRank + 1);
                }
                return (targetRank == startRank - 1);
            
            case(PieceType.Rook):
                // move forward and backward, i.e., rank + 1 or rank - 1
                // move right or left, i.e., file + 1 or file - 1
                // only changes rank OR file
                break;
            case(PieceType.Knight):
                break;
            case(PieceType.Bishop): 
                // move diagonally, i.e., rank +/- 1 and file +/- 1
                break;
            case(PieceType.Queen):
                // combination of rook and bishop, only one can be true
                break;
            case(PieceType.King):
                // queen with radius of one square
                break;
        }

        return true;
    }
}

