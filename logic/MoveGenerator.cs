using common.models;
using common.models.pieces;

namespace logic;

public class MoveGenerator
{
    public string GenerateMove(int startRank, int startFile, int targetRank, int targetFile)
    {
        string newFen = "rnbqkbnr/ppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";

        return newFen;
    }
}