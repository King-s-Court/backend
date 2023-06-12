namespace data.models;

public class Move
{
    public Guid Id { get; set; }
    public Square StartSquare { get; set; }
    public Square EndSquare { get; set; }
    public PieceColor PieceColor { get; set; }
    public PieceType PieceType { get; set; }
    public bool IsCapture { get; set; }
    public bool IsCheck { get; set; }
    public bool IsCheckmate { get; set; }
    public bool IsStalemate { get; set; }
    public bool IsCastle { get; set; }
    public bool IsEnPassant { get; set; }
    public bool IsPromotion { get; set; }
    public PieceType PromotionPieceType { get; set; }
    public DateTime MoveTime { get; set; }
}