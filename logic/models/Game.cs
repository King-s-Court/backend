namespace common.models;

public class Game
{
	public int GameId { get; set; }
	public Board GameBoard { get; set; }

	public Game(int gameId, Board board)
	{
		GameBoard = board;
		GameId = gameId;
	}
}