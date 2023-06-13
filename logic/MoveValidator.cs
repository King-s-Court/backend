using common.models;
using common.models.pieces;

namespace logic;

public static class MoveValidator
{
    // General validation of a move that will contain all other checks
    public static bool IsValid(Board board, int startRank, int startFile, int targetRank, int targetFile)
    {
        return IsValidTypeMove(board, startRank, startFile, targetRank, targetFile);
    }

    // Returns true if the piece can move according to its type if it was alone on the chess board
    public static bool IsValidTypeMove(Board board, int startRank, int startFile, int targetRank, int targetFile)
    {
        Piece? piece = board.GetPiece(startRank, startFile);
        // Combine indexes of the 2D array Squares to get a single number index for each square
        var startIndex = startRank * 8 + startFile;
        var targetIndex = targetRank * 8 + targetFile;

        // Check whether both the start and end square are within bounds of the box, i.e. >=0 or <64
        if (startIndex is >= 0 and < 64 && targetIndex is >= 0 and < 64 && startIndex != targetIndex)
        {
            // Check for piece type first and switch based on that
            switch (piece?.PieceType)
            {
                case (PieceType.Juicer):
                    if (startFile == targetFile)
                    {
                        if (piece.PieceColor == PieceColor.White)
                        {
                            if (startRank - targetRank == 1)
                            {
                                return true;
                            }
                            if (startRank - targetRank == 2 && !(piece as Juicer).HasMoved)
                            {
                                return true;
                            }
                            return false;
                        }
                        else if (piece.PieceColor == PieceColor.Black)
                        {
                            if (targetRank - startRank == 1)
                            {
                                return true;
                            }
                            if (targetRank - startRank == 2 && !(piece as Juicer).HasMoved)
                            {
                                return true;
                            }
                            return false;
                        }
                    }
                    return false;
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

    public static List<(int rank, int file)> GetAllPossibleTargets(int startRank, int startFile, Board board)
    {
        var _possibleTargets = new List<(int rank, int file)> { };
        for (int targetRank = 0; targetRank < 8; targetRank++)
        {
            for (int targetFile = 0; targetFile < 8; targetFile++)
            {
                if (IsValidTypeMove(board, startRank, startFile, targetRank, targetFile))
                {
                    _possibleTargets.Add((targetRank, targetFile));
                }
            }
        }
        return _possibleTargets;
    }

    public static List<(int rank, int file)> PathOccupants(int startRank, int startFile, Board board)
    {
        var _possibleTargetsRaw = GetAllPossibleTargets(startRank, startFile, board);
        var _possibleTargetsOccupied = new List<(int rank, int file)> { };
        var piece = board.GetPiece(startRank, startFile);

        foreach ((int rank, int file) in _possibleTargetsRaw)
        {
            if (board.IsOccupied(rank, file))
            {
                _possibleTargetsOccupied.Add((rank, file));
            }
        }
        return _possibleTargetsOccupied;
    }

    /*public static string GetMoveDirection(int startRank, int startFile, int targetRank, int targetFile, Board board)
	{
		Piece movingPiece = board.GetPiece(startRank, startFile);
		int rankDiff = targetRank - startRank;
		int fileDiff = targetFile - startFile;

		if (rankDiff == 0 && fileDiff == 0)
		{
			throw new InvalidOperationException("Invalid move");
		}
		if (movingPiece.PieceType is not PieceType.Knight)
		{
			if()
		}
		else
		{
			return "knight";
		}

	}*/
}
