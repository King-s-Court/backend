using Xunit;
using common.models;
using common.models.pieces;
using logic;
using System.Collections.Generic;

namespace Tests
{
	public class MoveTester
	{
		Board testBoard = new();

		[Fact]
		// TODO: this will be runnable for moved pawns as well once IsMoved is implemented for retrieving a pawn from board instead of instantiating a pawn manually
		public void CheckPawnTypeMove()
		{
			FENInterpreter.LoadBoardFromFEN(testBoard, "8/8/8/8/3P4/8/8/8 w KQkq - 0 1");

			// pawn not moved
			Assert.True(MoveValidator.IsValidTypeMove(testBoard, 4, 3, 3, 3));
			Assert.True(MoveValidator.IsValidTypeMove(testBoard, 4, 3, 3, 3));

			// pawn moved
			// Assert.True(MoveValidator.IsValidTypeMove(testBoard, 6, 0, 5, 0));
			// Assert.False(MoveValidator.IsValidTypeMove(testBoard, 6, 0, 4, 0));

			// random movement
			Assert.False(MoveValidator.IsValidTypeMove(testBoard, 4, 3, 2, 4));
			Assert.False(MoveValidator.IsValidTypeMove(testBoard, 4, 3, 2, 4));

			// out of bounds move
			Assert.False(MoveValidator.IsValidTypeMove(testBoard, 4, 3, -1, -1));
		}

		[Fact]
		public void CheckRookTypeMove()
		{
			FENInterpreter.LoadBoardFromFEN(testBoard, "8/8/8/8/3R4/8/8/8 w KQkq - 0 1");

			// valid move north (rank - file =)
			Assert.True(MoveValidator.IsValidTypeMove(testBoard, 4, 3, 3, 3));

			// valid move east (rank = file +)   
			Assert.True(MoveValidator.IsValidTypeMove(testBoard, 4, 3, 4, 4));

			// valid move south (rank + file =)
			Assert.True(MoveValidator.IsValidTypeMove(testBoard, 4, 3, 5, 3));

			// valid move west (rank = file -)
			Assert.True(MoveValidator.IsValidTypeMove(testBoard, 4, 3, 4, 2));

			// invalid move 
			Assert.False(MoveValidator.IsValidTypeMove(testBoard, 4, 3, 3, 4));

			// out of bounds move
			Assert.False(MoveValidator.IsValidTypeMove(testBoard, 4, 3, -1, -1));
		}

		[Fact]
		public void CheckKnightTypeMove()
		{
			FENInterpreter.LoadBoardFromFEN(testBoard, "8/8/8/8/3N4/8/8/8 w KQkq - 0 1");

			// valid move north-north-east (rank -2 file +1)
			Assert.True(MoveValidator.IsValidTypeMove(testBoard, 4, 3, 2, 4));

			// valid move north-east-east (rank -1 file +2)
			Assert.True(MoveValidator.IsValidTypeMove(testBoard, 4, 3, 3, 5));

			// valid move south-east-east (rank +1 file +2)
			Assert.True(MoveValidator.IsValidTypeMove(testBoard, 4, 3, 5, 5));

			// valid move south-south-east (rank +2 file +1)
			Assert.True(MoveValidator.IsValidTypeMove(testBoard, 4, 3, 6, 4));

			// valid move south-south-west (rank +2 file -1)
			Assert.True(MoveValidator.IsValidTypeMove(testBoard, 4, 3, 6, 2));

			// valid move south-west-west (rank +1 file -2)
			Assert.True(MoveValidator.IsValidTypeMove(testBoard, 4, 3, 5, 1));

			// valid move north-west-west (rank -1 file -2)
			Assert.True(MoveValidator.IsValidTypeMove(testBoard, 4, 3, 3, 1));

			// valid move north-north-west (rank -2 file -1)
			Assert.True(MoveValidator.IsValidTypeMove(testBoard, 4, 3, 2, 2));

			// invalid move
			Assert.False(MoveValidator.IsValidTypeMove(testBoard, 4, 3, 7, 7));

			// out of bounds move
			Assert.False(MoveValidator.IsValidTypeMove(testBoard, 4, 3, -1, -1));
		}

		[Fact]
		public void CheckBishopTypeMove()
		{
			FENInterpreter.LoadBoardFromFEN(testBoard, "8/8/8/8/3B4/8/8/8 w KQkq - 0 1");

			// valid move north-east (rank -1 file +1)
			Assert.True(MoveValidator.IsValidTypeMove(testBoard, 4, 3, 3, 4));

			// valid move south-east (rank +1 file +1)
			Assert.True(MoveValidator.IsValidTypeMove(testBoard, 4, 3, 5, 4));

			// valid move south-west (rank +1 file -1)
			Assert.True(MoveValidator.IsValidTypeMove(testBoard, 4, 3, 5, 2));

			// valid move north-west (rank -1 file -1)
			Assert.True(MoveValidator.IsValidTypeMove(testBoard, 4, 3, 3, 2));

			// invalid move
			Assert.False(MoveValidator.IsValidTypeMove(testBoard, 4, 3, 0, 0));

			// out of bounds move
			Assert.False(MoveValidator.IsValidTypeMove(testBoard, 4, 3, -1, -1));
		}

		[Fact]
		public void CheckQueenTypeMove()
		{
			FENInterpreter.LoadBoardFromFEN(testBoard, "8/8/8/8/3Q4/8/8/8 w KQkq - 0 1");

			// rook type moves

			// valid move north (rank - file =)
			Assert.True(MoveValidator.IsValidTypeMove(testBoard, 4, 3, 3, 3));

			// valid move east (rank = file +)   
			Assert.True(MoveValidator.IsValidTypeMove(testBoard, 4, 3, 4, 4));

			// valid move south (rank + file =)
			Assert.True(MoveValidator.IsValidTypeMove(testBoard, 4, 3, 5, 3));

			// valid move west (rank = file -)
			Assert.True(MoveValidator.IsValidTypeMove(testBoard, 4, 3, 4, 2));

			// out of bounds move
			Assert.False(MoveValidator.IsValidTypeMove(testBoard, 4, 3, -1, -1));

			// bishop type moves
			
			// valid move north-east (rank -1 file +1)
			Assert.True(MoveValidator.IsValidTypeMove(testBoard, 4, 3, 3, 4));

			// valid move south-east (rank +1 file +1)
			Assert.True(MoveValidator.IsValidTypeMove(testBoard, 4, 3, 5, 4));

			// valid move south-west (rank +1 file -1)
			Assert.True(MoveValidator.IsValidTypeMove(testBoard, 4, 3, 5, 2));

			// valid move north-west (rank -1 file -1)
			Assert.True(MoveValidator.IsValidTypeMove(testBoard, 4, 3, 3, 2));

			// invalid move
			Assert.False(MoveValidator.IsValidTypeMove(testBoard, 4, 3, 0, 0));

			// out of bounds move
			Assert.False(MoveValidator.IsValidTypeMove(testBoard, 4, 3, -1, -1));
			
		}

		[Fact]
		public void CheckKingTypeMove()
		{
			FENInterpreter.LoadBoardFromFEN(testBoard, "8/8/8/8/3K4/8/8/8 w KQkq - 0 1");

			// valid move north (rank - file =)
			Assert.True(MoveValidator.IsValidTypeMove(testBoard, 4, 3, 3, 3));

			// valid move east (rank = file +)   
			Assert.True(MoveValidator.IsValidTypeMove(testBoard, 4, 3, 4, 4));

			// valid move south (rank + file =)
			Assert.True(MoveValidator.IsValidTypeMove(testBoard, 4, 3, 5, 3));

			// valid move west (rank = file -)
			Assert.True(MoveValidator.IsValidTypeMove(testBoard, 4, 3, 4, 2));

			// valid move north-east (rank -1 file +1)
			Assert.True(MoveValidator.IsValidTypeMove(testBoard, 4, 3, 3, 4));

			// valid move south-east (rank +1 file +1)
			Assert.True(MoveValidator.IsValidTypeMove(testBoard, 4, 3, 5, 4));

			// valid move south-west (rank +1 file -1)
			Assert.True(MoveValidator.IsValidTypeMove(testBoard, 4, 3, 5, 2));

			// valid move north-west (rank -1 file -1)
			Assert.True(MoveValidator.IsValidTypeMove(testBoard, 4, 3, 3, 2));

			//invalid move too far
			Assert.False(MoveValidator.IsValidTypeMove(testBoard, 4, 3, 2, 3));

			// out of bounds move
			Assert.False(MoveValidator.IsValidTypeMove(testBoard, 4, 3, -1, -1));
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
			FENInterpreter.LoadBoardFromFEN(testBoard);

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
			Assert.Equal(_whiteQueenSideRookExpectedTargets, MoveValidator.GetAllPossibleTargets(7, 0, testBoard));

			// correct white king side rook moves
			Assert.Equal(_whiteKingSideRookExpectedTargets, MoveValidator.GetAllPossibleTargets(7, 7, testBoard));

			// correct black queen side rook moves
			Assert.Equal(_blackQueenSideRookExpectedTargets, MoveValidator.GetAllPossibleTargets(0, 0, testBoard));

			// correct black king side rook moves
			Assert.Equal(_blackKingSideRookExpectedTargets, MoveValidator.GetAllPossibleTargets(0, 7, testBoard));
		}

		[Fact]
		public void CheckKnightPossibleTargetSquares()
		{
			FENInterpreter.LoadBoardFromFEN(testBoard);

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
			Assert.Equal(_whiteQueenSideKnightExpected, MoveValidator.GetAllPossibleTargets(7, 1, testBoard));

			// correct white king side knight moves
			Assert.Equal(_whiteKingSideKnightExpected, MoveValidator.GetAllPossibleTargets(7, 6, testBoard));

			// correct black queen side knight moves
			Assert.Equal(_blackQueenSideKnightExpected, MoveValidator.GetAllPossibleTargets(0, 1, testBoard));

			// correct black king side knight moves
			Assert.Equal(_blackKingSideKnightExpected, MoveValidator.GetAllPossibleTargets(0, 6, testBoard));
		}

		[Fact]
		public void CheckBishopPossibleTargetSquares()
		{
			FENInterpreter.LoadBoardFromFEN(testBoard);

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
			Assert.Equal(_whiteQueenSideBishopExpected, MoveValidator.GetAllPossibleTargets(7, 2, testBoard));

			// correct white king side bishop moves
			Assert.Equal(_whiteKingSideBishopExpected, MoveValidator.GetAllPossibleTargets(7, 5, testBoard));

			// correct black queen side bishop moves
			Assert.Equal(_blackQueenSideBishopExpected, MoveValidator.GetAllPossibleTargets(0, 2, testBoard));

			// correct black king side bishop moves
			Assert.Equal(_blackKingSideBishopExpected, MoveValidator.GetAllPossibleTargets(0, 5, testBoard));
		}

		[Fact]
		public void CheckQueenPossibleTargetSquares()
		{
			FENInterpreter.LoadBoardFromFEN(testBoard);

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
			Assert.Equal(_whiteQueenExpected, MoveValidator.GetAllPossibleTargets(7, 3, testBoard));

			// correct black queen moves
			Assert.Equal(_blackQueenExpected, MoveValidator.GetAllPossibleTargets(0, 3, testBoard));
		}

		[Fact]
		public void CheckKingPossibleTargetSquares()
		{
			FENInterpreter.LoadBoardFromFEN(testBoard);

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
			Assert.Equal(_whiteKingExpected, MoveValidator.GetAllPossibleTargets(7, 4, testBoard));

			// correct black king moves
			Assert.Equal(_blackKingExpected, MoveValidator.GetAllPossibleTargets(0, 4, testBoard));
		}
	}
}

