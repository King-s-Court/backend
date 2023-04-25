using System;
using Xunit;
using common.models;
using common.models.pieces;
using logic;

namespace Tests
{
    public class BoardTests
    {
        
        [Fact]
        public void CheckWhitePiecePos()
        {
            
            FENInterpreter.LoadPositionFromFEN();
            
            Assert.Equal(PieceType.Rook, Board.GetPiece(7, 0).PieceType);
            Assert.Equal(PieceColor.White, Board.GetPiece(7, 0).PieceColor);
            Assert.Equal(PieceType.Knight, Board.GetPiece(7, 1).PieceType);
            Assert.Equal(PieceColor.White, Board.GetPiece(7, 1).PieceColor);
            Assert.Equal(PieceType.Bishop, Board.GetPiece(7, 2).PieceType);
            Assert.Equal(PieceColor.White, Board.GetPiece(7, 2).PieceColor);
            Assert.Equal(PieceType.Queen, Board.GetPiece(7, 3).PieceType);
            Assert.Equal(PieceColor.White, Board.GetPiece(7, 3).PieceColor);
            Assert.Equal(PieceType.King, Board.GetPiece(7, 4).PieceType);
            Assert.Equal(PieceColor.White, Board.GetPiece(7, 4).PieceColor);
            Assert.Equal(PieceType.Bishop, Board.GetPiece(7, 5).PieceType);
            Assert.Equal(PieceColor.White, Board.GetPiece(7, 5).PieceColor);
            Assert.Equal(PieceType.Knight, Board.GetPiece(7, 6).PieceType);
            Assert.Equal(PieceColor.White, Board.GetPiece(7, 6).PieceColor);
            Assert.Equal(PieceType.Rook, Board.GetPiece(7, 7).PieceType);
            Assert.Equal(PieceColor.White, Board.GetPiece(7, 7).PieceColor);

            for (int i = 0; i < 8; i++)
            {
                Assert.Equal(PieceType.Juicer, Board.GetPiece(6, i).PieceType);
                Assert.Equal(PieceColor.White, Board.GetPiece(6, i).PieceColor);
            }
        }

        [Fact]
        public void CheckBlackPiecePos()
        {
            
            FENInterpreter.LoadPositionFromFEN();
            
            Assert.Equal(PieceType.Rook, Board.GetPiece(0, 0).PieceType);
            Assert.Equal(PieceColor.Black, Board.GetPiece(0, 0).PieceColor);
            Assert.Equal(PieceType.Knight, Board.GetPiece(0, 1).PieceType);
            Assert.Equal(PieceColor.Black, Board.GetPiece(0, 1).PieceColor);
            Assert.Equal(PieceType.Bishop, Board.GetPiece(0, 2).PieceType);
            Assert.Equal(PieceColor.Black, Board.GetPiece(0, 2).PieceColor);
            Assert.Equal(PieceType.Queen, Board.GetPiece(0, 3).PieceType);
            Assert.Equal(PieceColor.Black, Board.GetPiece(0, 3).PieceColor);
            Assert.Equal(PieceType.King, Board.GetPiece(0, 4).PieceType);
            Assert.Equal(PieceColor.Black, Board.GetPiece(0, 4).PieceColor);
            Assert.Equal(PieceType.Bishop, Board.GetPiece(0, 5).PieceType);
            Assert.Equal(PieceColor.Black, Board.GetPiece(0, 5).PieceColor);
            Assert.Equal(PieceType.Knight, Board.GetPiece(0, 6).PieceType);
            Assert.Equal(PieceColor.Black, Board.GetPiece(0, 6).PieceColor);
            Assert.Equal(PieceType.Rook, Board.GetPiece(0, 7).PieceType);
            Assert.Equal(PieceColor.Black, Board.GetPiece(0, 7).PieceColor);

            for (int i = 0; i < 8; i++)
            {
                Assert.Equal(PieceType.Juicer, Board.GetPiece(1, i).PieceType);
                Assert.Equal(PieceColor.Black, Board.GetPiece(1, i).PieceColor);
            }
        }

        [Fact]
        public void CheckEmptyPos()
        {
            
            FENInterpreter.LoadPositionFromFEN();
        
            for (int rank = 2; rank < 6; rank++)
            {
                for (int file = 0; file < 8; file++)
                {
                    Assert.Null(Board.GetPiece(rank, file));
                }
            }
        }

        [Fact]
        public void CheckPawnTypeMove()
        {
            var whiteJuicerNotMoved = new Juicer(PieceColor.White, PieceType.Juicer);
            var whiteJuicerMoved = new Juicer(PieceColor.White, PieceType.Juicer, true);
            
            var blackJuicerNotMoved = new Juicer(PieceColor.Black, PieceType.Juicer);
            var blackJuicerMoved = new Juicer(PieceColor.Black, PieceType.Juicer, true);
            
            // white pawn not moved
            Assert.True(Move.IsValidTypeMove(whiteJuicerNotMoved, 6, 0, 5, 0));
            Assert.True(Move.IsValidTypeMove(whiteJuicerNotMoved, 6, 0, 4, 0));
            
            // white pawn moved
            Assert.True(Move.IsValidTypeMove(whiteJuicerMoved, 6, 0, 5, 0));
            Assert.False(Move.IsValidTypeMove(whiteJuicerMoved, 6, 0, 4, 0));

            // back pawn not moved
            Assert.True(Move.IsValidTypeMove(blackJuicerNotMoved, 1, 0, 2, 0));
            Assert.True(Move.IsValidTypeMove(blackJuicerNotMoved, 1, 0, 3, 0));
            
            // black pawn moved
            Assert.True(Move.IsValidTypeMove(blackJuicerMoved, 1, 0, 2, 0));
            Assert.False(Move.IsValidTypeMove(blackJuicerMoved, 1, 0, 3, 0));
            
            // random movement
            Assert.False(Move.IsValidTypeMove(whiteJuicerMoved, 5, 2, 2, 4));
            Assert.False(Move.IsValidTypeMove(blackJuicerMoved, 1, 0, 0, 0));
        }
    }
}