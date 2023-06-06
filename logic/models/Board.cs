using System.Text;

namespace common.models;

public static class Board
{
	// [ranks, files]
	private static Square[,] Squares = new Square[8, 8];
	public static string ToMove { get; set; }
	public static string CastlingRights { get; set; }
	public static string EnPassant { get; set; }
	public static string HalfmoveClock { get; set; }
	public static string FullmoveClock { get; set; }

	static Board()
	{
		ToMove = "w";
		CastlingRights = "KQkq";
		EnPassant = "-";
		for (int rank = 0; rank < 8; rank++)
		{
			for (int file = 0; file < 8; file++)
			{
				Squares[rank, file] = new Square();
			}
		}
	}

	public static Square[,] GetBoardSquares()
	{
		return Squares;
	}

	public static void AddPiece(int rank, int file, Piece piece)
	{
		Squares[rank, file].SquarePiece = piece;
	}

	public static Piece GetPiece(int rank, int file)
	{
		return Squares[rank, file].SquarePiece;
	}

	public static bool IsOccupied(int rank, int file)
	{
		return GetPiece(rank, file) is not null;
	}

	public static string AsFENString()
	{
		StringBuilder fenBuilder = new();

		for (int rank = 0; rank < 8; rank++)
		{
			int emptySquares = 0;
			for (int file = 0; file < 8; file++)
			{
				if (!IsOccupied(rank, file))
				{
					emptySquares++;
				}
				
				else
				{
					if (emptySquares > 0)
					{
						fenBuilder.Append(emptySquares);
						emptySquares = 0;
					}
					fenBuilder.Append(GetPiece(rank, file).AsFENChar());
				}
			}

			if (emptySquares > 0)
			{
				fenBuilder.Append(emptySquares);
			}

			if (rank < 7)
			{
				fenBuilder.Append("/");
			}

		}
		fenBuilder.Append($" {ToMove} {CastlingRights} {EnPassant} {HalfmoveClock} {FullmoveClock}");
		return fenBuilder.ToString();

	}
}