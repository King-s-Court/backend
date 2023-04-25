using Xunit;
using common.models;
using logic;

namespace Tests
{
    public class BoardTests
    {

        [Fact]
        public void CheckBlackPiecePos()
        {
            string defaultFen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
            
            FENInterpreter.LoadPositionFromFEN(defaultFen);
            
            Assert.Equal(Type.Rook, Board.Squares[0].Type);
            Assert.Equal(Color.Black, Board.Squares[0].Color);
            Assert.Equal(Type.Knight, Board.Squares[1].Type);
            Assert.Equal(Color.Black, Board.Squares[1].Color);
            Assert.Equal(Type.Bishop, Board.Squares[2].Type);
            Assert.Equal(Color.Black, Board.Squares[2].Color);
            Assert.Equal(Type.Queen, Board.Squares[3].Type);
            Assert.Equal(Color.Black, Board.Squares[3].Color);
            Assert.Equal(Type.King, Board.Squares[4].Type);
            Assert.Equal(Color.Black, Board.Squares[4].Color);
            Assert.Equal(Type.Bishop, Board.Squares[5].Type);
            Assert.Equal(Color.Black, Board.Squares[5].Color);
            Assert.Equal(Type.Knight, Board.Squares[6].Type);
            Assert.Equal(Color.Black, Board.Squares[6].Color);
            Assert.Equal(Type.Rook, Board.Squares[7].Type);
            Assert.Equal(Color.Black, Board.Squares[7].Color);
            
            for (int i = 8; i < 16; i++)
            {
                Assert.Equal(Type.Pawn, Board.Squares[i].Type);
                Assert.Equal(Color.Black, Board.Squares[i].Color);
            }
        }

        [Fact]
        public void CheckEmptyPos()
        {
            string defaultFen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
            
            FENInterpreter.LoadPositionFromFEN(defaultFen);
            
            for (int i = 16; i < 48; i++)
            {
                Assert.Null(Board.Squares[i]);
            }
        }

        [Fact]

        public void CheckWhitePiecePos()
        {
            string defaultFen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
            
            FENInterpreter.LoadPositionFromFEN(defaultFen);
            
            for (int i = 48; i < 56; i++)
            {
                Assert.Equal(Type.Pawn, Board.Squares[i].Type);
                Assert.Equal(Color.White, Board.Squares[i].Color);
            }
            
            Assert.Equal(Type.Rook, Board.Squares[56].Type);
            Assert.Equal(Color.White, Board.Squares[56].Color);
            Assert.Equal(Type.Knight, Board.Squares[57].Type);
            Assert.Equal(Color.White, Board.Squares[57].Color);
            Assert.Equal(Type.Bishop, Board.Squares[58].Type);
            Assert.Equal(Color.White, Board.Squares[58].Color);
            Assert.Equal(Type.Queen, Board.Squares[59].Type);
            Assert.Equal(Color.White, Board.Squares[59].Color);
            Assert.Equal(Type.King, Board.Squares[60].Type);
            Assert.Equal(Color.White, Board.Squares[60].Color);
            Assert.Equal(Type.Bishop, Board.Squares[61].Type);
            Assert.Equal(Color.White, Board.Squares[61].Color);
            Assert.Equal(Type.Knight, Board.Squares[62].Type);
            Assert.Equal(Color.White, Board.Squares[62].Color);
            Assert.Equal(Type.Rook, Board.Squares[63].Type);
            Assert.Equal(Color.White, Board.Squares[63].Color);
        }
    }
}