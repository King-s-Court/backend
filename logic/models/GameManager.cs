namespace common.models;

public class GameManager
{
    public static List<Game> _gameRepository = new();

    public static void AddGame(Game game)
    {
        _gameRepository.Add(game);
    }

    public static Game GetGame(int gameId)
    {
        return _gameRepository.Find(game => game.GameId == gameId);
    }
}