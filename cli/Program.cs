using logic;

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

MoveValidator.GetAllPossibleTargets(0, 4);
