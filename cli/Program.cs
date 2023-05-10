using logic;

//4kb1r/p1pRqppp/1p6/8/b4NP1/4B2P/PP3P2/5RK1 w k - 0 21

Console.WriteLine("Please enter a FEN code: ");
string? FEN = Console.Read();
FENInterpreter.LoadPositionFromFEN(FEN ?? "");

BoardVisualizer.VisualizeBoardFromFEN();