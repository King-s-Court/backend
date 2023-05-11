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

            FENInterpreter.LoadBoardFromFEN();

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

            FENInterpreter.LoadBoardFromFEN();

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

            FENInterpreter.LoadBoardFromFEN();

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

            // out of bounds move
            Assert.False(Move.IsValidTypeMove(whiteJuicerMoved, 0, 0, -1, -1));
        }

        [Fact]
        public void CheckRookTypeMove()
        {
            var whiteRook = new Rook(PieceColor.White, PieceType.Rook);

            // valid move up (rank -7 file 0)
            Assert.True(Move.IsValidTypeMove(whiteRook, 7, 0, 0, 0));

            // valid move right (rank 0 file +7)   
            Assert.True(Move.IsValidTypeMove(whiteRook, 7, 0, 7, 7));

            // valid move down (rank +7 file 0)
            Assert.True(Move.IsValidTypeMove(whiteRook, 0, 0, 7, 0));

            // valid move left (rank 0 file -7)
            Assert.True(Move.IsValidTypeMove(whiteRook, 7, 7, 7, 0));

            // invalid move 
            Assert.False(Move.IsValidTypeMove(whiteRook, 7, 0, 0, 7));

            // out of bounds move
            Assert.False(Move.IsValidTypeMove(whiteRook, 0, 0, -1, -1));
        }

        [Fact]
        public void CheckKnightTypeMove()
        {
            var whiteKnight = new Knight(PieceColor.White, PieceType.Knight);

            // valid move north-east (rank -2 file +1)
            Assert.True(Move.IsValidTypeMove(whiteKnight, 3, 3, 1, 4));

            // valid move south-east (rank +2 file +1)
            Assert.True(Move.IsValidTypeMove(whiteKnight, 3, 3, 5, 2));

            // valid move north-west (rank -2 file -1)
            Assert.True(Move.IsValidTypeMove(whiteKnight, 3, 3, 1, 2));

            // valid move south-west (rank +2 file -1)
            Assert.True(Move.IsValidTypeMove(whiteKnight, 3, 3, 5, 2));

            // invalid move
            Assert.False(Move.IsValidTypeMove(whiteKnight, 0, 0, 7, 7));

            // out of bounds move
            Assert.False(Move.IsValidTypeMove(whiteKnight, 0, 0, -1, -1));
        }

        [Fact]
        public void CheckBishopTypeMove()
        {
            var whiteBishop = new Bishop(PieceColor.White, PieceType.Bishop);

            // valid move north-east (rank -1 file +1)
            Assert.True(Move.IsValidTypeMove(whiteBishop, 3, 3, 2, 4));

            // valid move south-east (rank +1 file +1)
            Assert.True(Move.IsValidTypeMove(whiteBishop, 3, 3, 4, 4));

            // valid move south-west (rank +1 file -1)
            Assert.True(Move.IsValidTypeMove(whiteBishop, 3, 3, 4, 2));

            // valid move north-west (rank -1 file -1)
            Assert.True(Move.IsValidTypeMove(whiteBishop, 3, 3, 2, 2));

            // invalid move diagonally
            Assert.False(Move.IsValidTypeMove(whiteBishop, 7, 0, 1, 7));

            // invalid move straight
            Assert.False(Move.IsValidTypeMove(whiteBishop, 7, 0, 0, 0));

            // out of bounds move
            Assert.False(Move.IsValidTypeMove(whiteBishop, 3, 3, -1, -1));
        }

        [Fact]
        public void CheckQueenTypeMove()
        {
            var whiteQueen = new Queen(PieceColor.White, PieceType.Queen);

            // valid move north-east (rank -1 file +1)
            Assert.True(Move.IsValidTypeMove(whiteQueen, 3, 3, 2, 4));

            // valid move south-east (rank +1 file +1)
            Assert.True(Move.IsValidTypeMove(whiteQueen, 3, 3, 4, 4));

            // valid move south-west (rank +1 file -1)
            Assert.True(Move.IsValidTypeMove(whiteQueen, 3, 3, 4, 2));

            // valid move north-west (rank -1 file -1)
            Assert.True(Move.IsValidTypeMove(whiteQueen, 3, 3, 2, 2));

            // valid move up (rank -7 file 0)
            Assert.True(Move.IsValidTypeMove(whiteQueen, 7, 0, 0, 0));

            // valid move right (rank 0 file +7)
            Assert.True(Move.IsValidTypeMove(whiteQueen, 7, 0, 7, 7));

            // valid move down (rank +7 file 0)
            Assert.True(Move.IsValidTypeMove(whiteQueen, 0, 0, 7, 0));

            // valid move left (rank 0 file -7)
            Assert.True(Move.IsValidTypeMove(whiteQueen, 7, 7, 7, 0));

            // invalid move diagonally
            Assert.False(Move.IsValidTypeMove(whiteQueen, 7, 3, 6, 5));

            // out of bounds move
            Assert.False(Move.IsValidTypeMove(whiteQueen, 3, 3, -1, -1));
        }

        [Fact]
        public void CheckKingTypeMove()
        {
            var whiteKing = new King(PieceColor.White, PieceType.King);

            // valid move up (rank -1 file 0)
            Assert.True(Move.IsValidTypeMove(whiteKing, 5, 3, 4, 3));

            // valid move right (rank 0 file +1)
            Assert.True(Move.IsValidTypeMove(whiteKing, 5, 3, 5, 4));

            // valid move down (rank +1 file 0)
            Assert.True(Move.IsValidTypeMove(whiteKing, 5, 3, 6, 3));

            // valid move left (rank 0 file -1)
            Assert.True(Move.IsValidTypeMove(whiteKing, 5, 3, 5, 2));

            // valid move north-east (rank -1 file +1)
            Assert.True(Move.IsValidTypeMove(whiteKing, 5, 3, 4, 4));

            // valid move south-east (rank +1 file +1)
            Assert.True(Move.IsValidTypeMove(whiteKing, 5, 3, 6, 4));

            // valid move south-west (rank +1 file -1)
            Assert.True(Move.IsValidTypeMove(whiteKing, 5, 3, 6, 2));

            // valid move north-west (rank -1 file -1)
            Assert.True(Move.IsValidTypeMove(whiteKing, 5, 3, 4, 2));

            //invalid move too far
            Assert.False(Move.IsValidTypeMove(whiteKing, 5, 3, 3, 1));

            // out of bounds move
            Assert.False(Move.IsValidTypeMove(whiteKing, 5, 3, -1, -1));
        }

        [Fact]
        public void ValidateFENStrings()
        {
            // Correct FEN string 
            Assert.True(FENInterpreter.IsValidFEN("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1"));

            // Incorrect FEN string
            Assert.False(FENInterpreter.IsValidFEN("brum brum"));
        }
    }
}