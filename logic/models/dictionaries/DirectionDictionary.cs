using common.models.pieces;
namespace common.models;

public static class DirectionDictionary
{

    /// <summary>
    /// Dictionary storing the directions based on the rank and file change.
    /// </summary>
    public static readonly Dictionary<(bool rank, bool file), string> _directions = new()
    {
        // {(true, true), PieceType.Bishop},
        // {(true, false), PieceType.Rook},
        // {(false, true), PieceType.Rook}
    };
}