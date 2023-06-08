using logic;
using common.models;

// 4kb1r/p1pRqppp/1p6/8/b4NP1/4B2P/PP3P2/5RK1 w k - 0 21

Console.Clear();
Console.WriteLine("Please enter a FEN code: ");
string? FEN = Console.ReadLine();

if (string.IsNullOrEmpty(FEN))
{
    Console.WriteLine("Using default FEN");
    FENInterpreter.LoadBoardFromFEN();
    FENInterpreter.LoadGameDataFromFEN();
    BoardVisualizer.VisualizeBoardFromSquares();
}

else if (!FENInterpreter.IsValidFEN(FEN))
{
    Console.WriteLine("Invalid FEN string.");
}

else
{
    Console.WriteLine($"Using {FEN}");
    FENInterpreter.LoadBoardFromFEN(FEN);
    FENInterpreter.LoadGameDataFromFEN(FEN);
    BoardVisualizer.VisualizeBoardFromSquares();
}
BoardVisualizer.VisualizeBoardForSystemCoords();

Console.WriteLine("Targeting piece @ RANK: ");
int rank = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Targeting piece @ FILE: ");
int file = Convert.ToInt32(Console.ReadLine());

List<(int rank, int file)> possibleOccupiedTargets = MoveValidator.PathOccupants(rank, file);

Console.WriteLine($"Path occupants for {Board.GetPiece(rank, file).AsString()}:");

foreach ((int rank, int file) square in possibleOccupiedTargets)
{
    Console.WriteLine($"{Board.GetPiece(square.rank, square.file).AsString()} at [{square.rank}:{square.file}]");
}

Console.WriteLine($"Board as FEN string: {Board.AsFENString()}");

// MoveValidator.GetMoveDirection(rank, file);

