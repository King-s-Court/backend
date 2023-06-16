using logic;
using common.models;
using common.models.pieces;

// random FEN
// 4kb1r/p1pRqppp/1p6/8/b4NP1/4B2P/PP3P2/5RK1 w k - 0 21

// no pawn FEN
// rnbqkbnr/8/8/8/8/8/8/RNBQKBNR w KQkq - 0 1

// SETUP

Console.Clear();
// Console.WriteLine("Please enter a FEN code: ");
// string? FEN = Console.ReadLine();
// Console.Clear();
Board board = new();

// if (string.IsNullOrEmpty(FEN))
// {
FENInterpreter.LoadBoardFromFEN(board);
FENInterpreter.LoadGameDataFromFEN(board);
BoardVisualizer.VisualizeBoardFromSquares(board);
// }

// else if (!FENInterpreter.IsValidFEN(FEN))
// {
//     Console.WriteLine("Invalid FEN string.");
// }

// else
// {
//     FENInterpreter.LoadBoardFromFEN(board, FEN);
//     FENInterpreter.LoadGameDataFromFEN(board, FEN);
//     BoardVisualizer.VisualizeBoardFromSquares(board);
// }

// PLAY

while (true)
{
    Console.WriteLine("Moving piece start rank, start file, target rank, target file: ");
    string moveCoords = Console.ReadLine();

    int sRank = Convert.ToInt32(moveCoords.Split(' ')[0]);
    int sFile = Convert.ToInt32(moveCoords.Split(' ')[1]);
    int tRank = Convert.ToInt32(moveCoords.Split(' ')[2]);
    int tFile = Convert.ToInt32(moveCoords.Split(' ')[3]);

    Console.Clear();
}