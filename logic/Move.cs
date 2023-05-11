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
        var startIndex = startRank * 8 + startFile;
        var endIndex = targetRank * 8 + targetFile;
        if (startIndex is >= 0 and < 64 && endIndex is >= 0 and < 64)
        {
            switch (piece.PieceType)
            {
                case (PieceType.Juicer):
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

                case (PieceType.Rook):
                    return (startRank != targetRank && startFile == targetFile || startRank == targetRank && startFile != targetFile);

                case (PieceType.Knight):
                    return (Math.Abs(targetRank - startRank) == 2 && Math.Abs(targetFile - startFile) == 1 || Math.Abs(targetRank - startRank) == 1 && Math.Abs(targetFile - startFile) == 2);

                case (PieceType.Bishop):
                    return (Math.Abs(targetRank - startRank) == Math.Abs(targetFile - startFile));

                case (PieceType.Queen):
                    return ((Math.Abs(targetRank - startRank) == Math.Abs(targetFile - startFile)) || (startRank != targetRank && startFile == targetFile || startRank == targetRank && startFile != targetFile));

                case (PieceType.King):
                    return (Math.Abs(targetRank - startRank) == 1 && Math.Abs(targetFile - startFile) == 1 || Math.Abs(targetRank - startRank) == 1 && Math.Abs(targetFile - startFile) == 0 || Math.Abs(targetRank - startRank) == 0 && Math.Abs(targetFile - startFile) == 1);
            }
        }
        return false;
    }

    // public static bool IsClearPath()
	// {
		
	// }
}

