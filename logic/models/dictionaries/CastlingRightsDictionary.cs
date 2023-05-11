namespace common.models;

public static class CastlingRightsDictionary
{
    public static readonly Dictionary<char, string> _castlingRights = new()
    {
        {'K', "| White king's side | "},
        {'Q', "| White queen's side | "},
        {'k', "| Black king's side | "},
        {'q', "| Black queen's side | "},
        {'-', "| No castling rights |"}
    };
}