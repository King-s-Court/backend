using System;
using Xunit;
using common.models;
using common.models.pieces;
using logic;
using System.Collections.Generic;

namespace Tests
{
    // These tests are ran on a board in the intial state, i.e. the following fen string rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1
    public class BoardTests
    {
        Board testBoard = new();
        [Fact]
        public void CheckWhitePiecePos()
        {
            FENInterpreter.LoadBoardFromFEN(testBoard);

            Assert.Equal(PieceType.Rook, testBoard.GetPiece(7, 0)?.PieceType);
            Assert.Equal(PieceColor.White, testBoard.GetPiece(7, 0)?.PieceColor);
            Assert.Equal(PieceType.Knight, testBoard.GetPiece(7, 1)?.PieceType);
            Assert.Equal(PieceColor.White, testBoard.GetPiece(7, 1)?.PieceColor);
            Assert.Equal(PieceType.Bishop, testBoard.GetPiece(7, 2)?.PieceType);
            Assert.Equal(PieceColor.White, testBoard.GetPiece(7, 2)?.PieceColor);
            Assert.Equal(PieceType.Queen, testBoard.GetPiece(7, 3)?.PieceType);
            Assert.Equal(PieceColor.White, testBoard.GetPiece(7, 3)?.PieceColor);
            Assert.Equal(PieceType.King, testBoard.GetPiece(7, 4)?.PieceType);
            Assert.Equal(PieceColor.White, testBoard.GetPiece(7, 4)?.PieceColor);
            Assert.Equal(PieceType.Bishop, testBoard.GetPiece(7, 5)?.PieceType);
            Assert.Equal(PieceColor.White, testBoard.GetPiece(7, 5)?.PieceColor);
            Assert.Equal(PieceType.Knight, testBoard.GetPiece(7, 6)?.PieceType);
            Assert.Equal(PieceColor.White, testBoard.GetPiece(7, 6)?.PieceColor);
            Assert.Equal(PieceType.Rook, testBoard.GetPiece(7, 7)?.PieceType);
            Assert.Equal(PieceColor.White, testBoard.GetPiece(7, 7)?.PieceColor);

            for (int i = 0; i < 8; i++)
            {
                Assert.Equal(PieceType.Juicer, testBoard.GetPiece(6, i)?.PieceType);
                Assert.Equal(PieceColor.White, testBoard.GetPiece(6, i)?.PieceColor);
            }
        }

        [Fact]
        public void CheckBlackPiecePos()
        {
            FENInterpreter.LoadBoardFromFEN(testBoard);

            Assert.Equal(PieceType.Rook, testBoard.GetPiece(0, 0)?.PieceType);
            Assert.Equal(PieceColor.Black, testBoard.GetPiece(0, 0)?.PieceColor);
            Assert.Equal(PieceType.Knight, testBoard.GetPiece(0, 1)?.PieceType);
            Assert.Equal(PieceColor.Black, testBoard.GetPiece(0, 1)?.PieceColor);
            Assert.Equal(PieceType.Bishop, testBoard.GetPiece(0, 2)?.PieceType);
            Assert.Equal(PieceColor.Black, testBoard.GetPiece(0, 2)?.PieceColor);
            Assert.Equal(PieceType.Queen, testBoard.GetPiece(0, 3)?.PieceType);
            Assert.Equal(PieceColor.Black, testBoard.GetPiece(0, 3)?.PieceColor);
            Assert.Equal(PieceType.King, testBoard.GetPiece(0, 4)?.PieceType);
            Assert.Equal(PieceColor.Black, testBoard.GetPiece(0, 4)?.PieceColor);
            Assert.Equal(PieceType.Bishop, testBoard.GetPiece(0, 5)?.PieceType);
            Assert.Equal(PieceColor.Black, testBoard.GetPiece(0, 5)?.PieceColor);
            Assert.Equal(PieceType.Knight, testBoard.GetPiece(0, 6)?.PieceType);
            Assert.Equal(PieceColor.Black, testBoard.GetPiece(0, 6)?.PieceColor);
            Assert.Equal(PieceType.Rook, testBoard.GetPiece(0, 7)?.PieceType);
            Assert.Equal(PieceColor.Black, testBoard.GetPiece(0, 7)?.PieceColor);

            for (int i = 0; i < 8; i++)
            {
                Assert.Equal(PieceType.Juicer, testBoard.GetPiece(1, i)?.PieceType);
                Assert.Equal(PieceColor.Black, testBoard.GetPiece(1, i)?.PieceColor);
            }
        }

        [Fact]
        public void CheckEmptyPos()
        {
            FENInterpreter.LoadBoardFromFEN(testBoard);

            for (int rank = 2; rank < 6; rank++)
            {
                for (int file = 0; file < 8; file++)
                {
                    Assert.Null(testBoard.GetPiece(rank, file));
                }
            }
        }
    }
}
