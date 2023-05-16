using Xunit;
using common.models;
using common.models.pieces;
using logic;
using System.Collections.Generic;

namespace Tests
{
	public class MoveTester
	{
		[Fact]
		public void CheckPawnTypeMove()
		{
			var whiteJuicerNotMoved = new Juicer(PieceColor.White, PieceType.Juicer);
			var whiteJuicerMoved = new Juicer(PieceColor.White, PieceType.Juicer, true);

			var blackJuicerNotMoved = new Juicer(PieceColor.Black, PieceType.Juicer);
			var blackJuicerMoved = new Juicer(PieceColor.Black, PieceType.Juicer, true);

			// white pawn not moved
			Assert.True(MoveValidator.IsValidTypeMove(whiteJuicerNotMoved, 6, 0, 5, 0));
			Assert.True(MoveValidator.IsValidTypeMove(whiteJuicerNotMoved, 6, 0, 4, 0));

			// white pawn moved
			Assert.True(MoveValidator.IsValidTypeMove(whiteJuicerMoved, 6, 0, 5, 0));
			Assert.False(MoveValidator.IsValidTypeMove(whiteJuicerMoved, 6, 0, 4, 0));

			// back pawn not moved
			Assert.True(MoveValidator.IsValidTypeMove(blackJuicerNotMoved, 1, 0, 2, 0));
			Assert.True(MoveValidator.IsValidTypeMove(blackJuicerNotMoved, 1, 0, 3, 0));

			// black pawn moved
			Assert.True(MoveValidator.IsValidTypeMove(blackJuicerMoved, 1, 0, 2, 0));
			Assert.False(MoveValidator.IsValidTypeMove(blackJuicerMoved, 1, 0, 3, 0));

			// random movement
			Assert.False(MoveValidator.IsValidTypeMove(whiteJuicerMoved, 5, 2, 2, 4));
			Assert.False(MoveValidator.IsValidTypeMove(blackJuicerMoved, 1, 0, 0, 0));

			// out of bounds move
			Assert.False(MoveValidator.IsValidTypeMove(whiteJuicerMoved, 0, 0, -1, -1));
		}

		[Fact]
		public void CheckRookTypeMove()
		{
			var whiteRook = new Rook(PieceColor.White, PieceType.Rook);

			// valid move up (rank -7 file 0)
			Assert.True(MoveValidator.IsValidTypeMove(whiteRook, 7, 0, 0, 0));

			// valid move right (rank 0 file +7)   
			Assert.True(MoveValidator.IsValidTypeMove(whiteRook, 7, 0, 7, 7));

			// valid move down (rank +7 file 0)
			Assert.True(MoveValidator.IsValidTypeMove(whiteRook, 0, 0, 7, 0));

			// valid move left (rank 0 file -7)
			Assert.True(MoveValidator.IsValidTypeMove(whiteRook, 7, 7, 7, 0));

			// invalid move 
			Assert.False(MoveValidator.IsValidTypeMove(whiteRook, 7, 0, 0, 7));

			// out of bounds move
			Assert.False(MoveValidator.IsValidTypeMove(whiteRook, 0, 0, -1, -1));
		}

		[Fact]
		public void CheckKnightTypeMove()
		{
			var whiteKnight = new Knight(PieceColor.White, PieceType.Knight);

			// valid move north-east (rank -2 file +1)
			Assert.True(MoveValidator.IsValidTypeMove(whiteKnight, 3, 3, 1, 4));

			// valid move south-east (rank +2 file +1)
			Assert.True(MoveValidator.IsValidTypeMove(whiteKnight, 3, 3, 5, 2));

			// valid move north-west (rank -2 file -1)
			Assert.True(MoveValidator.IsValidTypeMove(whiteKnight, 3, 3, 1, 2));

			// valid move south-west (rank +2 file -1)
			Assert.True(MoveValidator.IsValidTypeMove(whiteKnight, 3, 3, 5, 2));

			// invalid move
			Assert.False(MoveValidator.IsValidTypeMove(whiteKnight, 0, 0, 7, 7));

			// out of bounds move
			Assert.False(MoveValidator.IsValidTypeMove(whiteKnight, 0, 0, -1, -1));
		}

		[Fact]
		public void CheckBishopTypeMove()
		{
			var whiteBishop = new Bishop(PieceColor.White, PieceType.Bishop);

			// valid move north-east (rank -1 file +1)
			Assert.True(MoveValidator.IsValidTypeMove(whiteBishop, 3, 3, 2, 4));

			// valid move south-east (rank +1 file +1)
			Assert.True(MoveValidator.IsValidTypeMove(whiteBishop, 3, 3, 4, 4));

			// valid move south-west (rank +1 file -1)
			Assert.True(MoveValidator.IsValidTypeMove(whiteBishop, 3, 3, 4, 2));

			// valid move north-west (rank -1 file -1)
			Assert.True(MoveValidator.IsValidTypeMove(whiteBishop, 3, 3, 2, 2));

			// invalid move diagonally
			Assert.False(MoveValidator.IsValidTypeMove(whiteBishop, 7, 0, 1, 7));

			// invalid move straight
			Assert.False(MoveValidator.IsValidTypeMove(whiteBishop, 7, 0, 0, 0));

			// out of bounds move
			Assert.False(MoveValidator.IsValidTypeMove(whiteBishop, 3, 3, -1, -1));
		}

		[Fact]
		public void CheckQueenTypeMove()
		{
			var whiteQueen = new Queen(PieceColor.White, PieceType.Queen);

			// valid move north-east (rank -1 file +1)
			Assert.True(MoveValidator.IsValidTypeMove(whiteQueen, 3, 3, 2, 4));

			// valid move south-east (rank +1 file +1)
			Assert.True(MoveValidator.IsValidTypeMove(whiteQueen, 3, 3, 4, 4));

			// valid move south-west (rank +1 file -1)
			Assert.True(MoveValidator.IsValidTypeMove(whiteQueen, 3, 3, 4, 2));

			// valid move north-west (rank -1 file -1)
			Assert.True(MoveValidator.IsValidTypeMove(whiteQueen, 3, 3, 2, 2));

			// valid move up (rank -7 file 0)
			Assert.True(MoveValidator.IsValidTypeMove(whiteQueen, 7, 0, 0, 0));

			// valid move right (rank 0 file +7)
			Assert.True(MoveValidator.IsValidTypeMove(whiteQueen, 7, 0, 7, 7));

			// valid move down (rank +7 file 0)
			Assert.True(MoveValidator.IsValidTypeMove(whiteQueen, 0, 0, 7, 0));

			// valid move left (rank 0 file -7)
			Assert.True(MoveValidator.IsValidTypeMove(whiteQueen, 7, 7, 7, 0));

			// invalid move diagonally
			Assert.False(MoveValidator.IsValidTypeMove(whiteQueen, 7, 3, 6, 5));

			// out of bounds move
			Assert.False(MoveValidator.IsValidTypeMove(whiteQueen, 3, 3, -1, -1));
		}

		[Fact]
		public void CheckKingTypeMove()
		{
			var whiteKing = new King(PieceColor.White, PieceType.King);

			// valid move up (rank -1 file 0)
			Assert.True(MoveValidator.IsValidTypeMove(whiteKing, 5, 3, 4, 3));

			// valid move right (rank 0 file +1)
			Assert.True(MoveValidator.IsValidTypeMove(whiteKing, 5, 3, 5, 4));

			// valid move down (rank +1 file 0)
			Assert.True(MoveValidator.IsValidTypeMove(whiteKing, 5, 3, 6, 3));

			// valid move left (rank 0 file -1)
			Assert.True(MoveValidator.IsValidTypeMove(whiteKing, 5, 3, 5, 2));

			// valid move north-east (rank -1 file +1)
			Assert.True(MoveValidator.IsValidTypeMove(whiteKing, 5, 3, 4, 4));

			// valid move south-east (rank +1 file +1)
			Assert.True(MoveValidator.IsValidTypeMove(whiteKing, 5, 3, 6, 4));

			// valid move south-west (rank +1 file -1)
			Assert.True(MoveValidator.IsValidTypeMove(whiteKing, 5, 3, 6, 2));

			// valid move north-west (rank -1 file -1)
			Assert.True(MoveValidator.IsValidTypeMove(whiteKing, 5, 3, 4, 2));

			//invalid move too far
			Assert.False(MoveValidator.IsValidTypeMove(whiteKing, 5, 3, 3, 1));

			// out of bounds move
			Assert.False(MoveValidator.IsValidTypeMove(whiteKing, 5, 3, -1, -1));
		}

		[Fact]
		public void ValidateFENStrings()
		{
			// Correct FEN string 
			Assert.True(FENInterpreter.IsValidFEN("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1"));

			// Incorrect FEN string
			Assert.False(FENInterpreter.IsValidFEN("brum brum"));
		}

		[Fact]
		public void CheckRookPossibleTargetSquares()
		{
			var _whiteQueenSideRookExpectedTargets = new List<(int, int)>
			{
				(0, 0),
				(1, 0),
				(2, 0),
				(3, 0),
				(4, 0),
				(5, 0),
				(6, 0),
				(7, 1),
				(7, 2),
				(7, 3),
				(7, 4),
				(7, 5),
				(7, 6),
				(7, 7),
			};

			var _whiteKingSideRookExpectedTargets = new List<(int, int)>
			{
				(0, 7),
				(1, 7),
				(2, 7),
				(3, 7),
				(4, 7),
				(5, 7),
				(6, 7),
				(7, 0),
				(7, 1),
				(7, 2),
				(7, 3),
				(7, 4),
				(7, 5),
				(7, 6),
			};

			var _blackQueenSideRookExpectedTargets = new List<(int, int)>
			{
				(0, 1),
				(0, 2),
				(0, 3),
				(0, 4),
				(0, 5),
				(0, 6),
				(0, 7),
				(1, 0),
				(2, 0),
				(3, 0),
				(4, 0),
				(5, 0),
				(6, 0),
				(7, 0),
			};

			var _blackKingSideRookExpectedTargets = new List<(int, int)>
			{
				(0, 0),
				(0, 1),
				(0, 2),
				(0, 3),
				(0, 4),
				(0, 5),
				(0, 6),
				(1, 7),
				(2, 7),
				(3, 7),
				(4, 7),
				(5, 7),
				(6, 7),
				(7, 7),
			};

			// correct white queen side rook moves
			Assert.Equal(_whiteQueenSideRookExpectedTargets, MoveValidator.GetAllPossibleTargets(7, 0));

			// correct white king side rook moves
			Assert.Equal(_whiteKingSideRookExpectedTargets, MoveValidator.GetAllPossibleTargets(7, 7));

			// correct black queen side rook moves
			Assert.Equal(_blackQueenSideRookExpectedTargets, MoveValidator.GetAllPossibleTargets(0, 0));

			// correct black king side rook moves
			Assert.Equal(_blackKingSideRookExpectedTargets, MoveValidator.GetAllPossibleTargets(0, 7));
		}

		[Fact]
		public void CheckKnightPossibleTargetSquares()
		{
			// 7 1
			var _whiteQueenSideKnightExpected = new List<(int, int)>
			{
				(5, 0),
				(5, 2),
				(6, 3)
			};

			// 7 6
			var _whiteKingSideKnightExpected = new List<(int, int)>
			{
				(5, 5),
				(5, 7),
				(6, 4)
			};

			// 0 1
			var _blackQueenSideKnightExpected = new List<(int, int)>
			{
				(1, 3),
				(2, 0),
				(2, 2)
			};

			// 0 6
			var _blackKingSideKnightExpected = new List<(int, int)>
			{
				(1, 4),
				(2, 5),
				(2, 7)
			};

			// correct white queen side knight moves
			Assert.Equal(_whiteQueenSideKnightExpected, MoveValidator.GetAllPossibleTargets(7, 1));

			// correct white king side knight moves
			Assert.Equal(_whiteKingSideKnightExpected, MoveValidator.GetAllPossibleTargets(7, 6));

			// correct black queen side knight moves
			Assert.Equal(_blackQueenSideKnightExpected, MoveValidator.GetAllPossibleTargets(0, 1));

			// correct black king side knight moves
			Assert.Equal(_blackKingSideKnightExpected, MoveValidator.GetAllPossibleTargets(0, 6));
		}

		[Fact]
		public void CheckBishopPossibleTargetSquares()
		{
			// 7 2
			var _whiteQueenSideBishopExpected = new List<(int, int)>
			{
				(2, 7),
				(3, 6),
				(4, 5),
				(5, 0),
				(5, 4),
				(6, 1),
				(6, 3)
			};

			// 7 5
			var _whiteKingSideBishopExpected = new List<(int, int)>
			{
				(2, 0),
				(3, 1),
				(4, 2),
				(5, 3),
				(5, 7),
				(6, 4),
				(6, 6)
			};
			// 0 2
			var _blackQueenSideBishopExpected = new List<(int, int)>
			{
				(1, 1),
				(1, 3),
				(2, 0),
				(2, 4),
				(3, 5),
				(4, 6),
				(5, 7)
			};

			// 0 5
			var _blackKingSideBishopExpected = new List<(int, int)>
			{
				(1, 4),
				(1, 6),
				(2, 3),
				(2, 7),
				(3, 2),
				(4, 1),
				(5, 0)
			};

			// correct white queen side bishop moves
			Assert.Equal(_whiteQueenSideBishopExpected, MoveValidator.GetAllPossibleTargets(7, 2));

			// correct white king side bishop moves
			Assert.Equal(_whiteKingSideBishopExpected, MoveValidator.GetAllPossibleTargets(7, 5));

			// correct black queen side bishop moves
			Assert.Equal(_blackQueenSideBishopExpected, MoveValidator.GetAllPossibleTargets(0, 2));

			// correct black king side bishop moves
			Assert.Equal(_blackKingSideBishopExpected, MoveValidator.GetAllPossibleTargets(0, 5));
		}

		[Fact]
		public void CheckQueenPossibleTargetSquares()
		{
			// 7 3
			var _whiteQueenExpected = new List<(int, int)>
			{
				(0, 3),
				(1, 3),
				(2, 3),
				(3, 3),
				(3, 7),
				(4, 0),
				(4, 3),
				(4, 6),
				(5, 1),
				(5, 3),
				(5, 5),
				(6, 2),
				(6, 3),
				(6, 4),
				(7, 0),
				(7, 1),
				(7, 2),
				(7, 4),
				(7, 5),
				(7, 6),
				(7, 7)
			};

			// 0 3
			var _blackQueenExpected = new List<(int, int)>
			{
				(0, 0),
				(0, 1),
				(0, 2),
				(0, 4),
				(0, 5),
				(0, 6),
				(0, 7),
				(1, 2),
				(1, 3),
				(1, 4),
				(2, 1),
				(2, 3),
				(2, 5),
				(3, 0),
				(3, 3),
				(3, 6),
				(4, 3),
				(4, 7),
				(5, 3),
				(6, 3),
				(7, 3)
			};

			// correct white queen moves
			Assert.Equal(_whiteQueenExpected, MoveValidator.GetAllPossibleTargets(7, 3));

			// correct black queen moves
			Assert.Equal(_blackQueenExpected, MoveValidator.GetAllPossibleTargets(0, 3));
		}

		[Fact]
		public void CheckKingPossibleTargetSquares()
		{
			// 7 4
			var _whiteKingExpected = new List<(int, int)>
			{
				(6, 3),
				(6, 4),
				(6, 5),
				(7, 3),
				(7, 5)
			};

			// 0 4
			var _blackKingExpected = new List<(int, int)>
			{
				(0, 3),
				(0, 5),
				(1, 3),
				(1, 4),
				(1, 5)
			};

			// correct white king moves
			Assert.Equal(_whiteKingExpected, MoveValidator.GetAllPossibleTargets(7, 4));

			// correct black king moves
			Assert.Equal(_blackKingExpected, MoveValidator.GetAllPossibleTargets(0, 4));
		}
	}
}

