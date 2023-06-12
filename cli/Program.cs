using logic;
using common.models;

// 4kb1r/p1pRqppp/1p6/8/b4NP1/4B2P/PP3P2/5RK1 w k - 0 21

Console.Clear();
Console.WriteLine("Please enter a FEN code: ");
string? FEN = Console.ReadLine();
Board board = new();

if (string.IsNullOrEmpty(FEN))
{
    Console.WriteLine("Using default FEN");
    FENInterpreter.LoadBoardFromFEN(board);
    FENInterpreter.LoadGameDataFromFEN(board);
    BoardVisualizer.VisualizeBoardFromSquares(board);
}

else if (!FENInterpreter.IsValidFEN(FEN))
{
    Console.WriteLine("Invalid FEN string.");
}

else
{
    Console.WriteLine($"Using {FEN}");
    FENInterpreter.LoadBoardFromFEN(board);
    FENInterpreter.LoadGameDataFromFEN(board);
    BoardVisualizer.VisualizeBoardFromSquares(board);
}
BoardVisualizer.VisualizeBoardForSystemCoords();

// Console.WriteLine("Targeting piece @ RANK: ");
// int rank = Convert.ToInt32(Console.ReadLine());

// Console.WriteLine("Targeting piece @ FILE: ");
// int file = Convert.ToInt32(Console.ReadLine());

// List<(int rank, int file)> possibleOccupiedTargets = MoveValidator.PathOccupants(rank, file, board);

// Console.WriteLine($"Path occupants for {board.GetPiece(rank, file).AsString()}:");

// foreach ((int rank, int file) square in possibleOccupiedTargets)
// {
// 	Console.WriteLine($"{board.GetPiece(square.rank, square.file).AsString()} at [{square.rank}:{square.file}]");
// }

Console.WriteLine($"Board as FEN string BEFORE move: {board.AsFENString()}");

Console.WriteLine("Moving piece start rank: ");
int startRank = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Moving piece start file: ");
int startFile = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Moving piece target rank: ");
int targetRank = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Moving piece target file: ");
int targetFile = Convert.ToInt32(Console.ReadLine());

Console.WriteLine($"Moving {board.GetPiece(startRank, startFile).AsString} from |{startRank}:{startFile}| to |{targetRank}:{targetFile}|...");
MoveGenerator.MakeMove(startRank, startFile, targetRank, targetFile, board);

BoardVisualizer.VisualizeBoardFromSquares(board);
// MoveValidator.GetMoveDirection(rank, file);

