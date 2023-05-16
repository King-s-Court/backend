using Xunit;
using common.models;
using logic;

namespace Tests
{
    // These tests are ran on a board in the intial state, i.e. the following fen string rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1
    public class FENTester
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
    }
}

