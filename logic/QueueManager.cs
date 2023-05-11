using common.Models;

public class QueueManager
{
    private readonly List<Player> _players = new();
    private readonly TimeSpan _checkInterval = TimeSpan.FromSeconds(5);

    public async Task CheckForMatch()
    {
        var matchedPlayers = _players.GroupBy(p => p.GameMode).FirstOrDefault(g => g.Count() >= 2);

        if (matchedPlayers != null)
        {
            // Create a new game using the matched players and remove them from the queue
            // You can use SignalR to create the game and notify the players that the game is starting
            foreach (var player in matchedPlayers)
            {
                _players.Remove(player);
            }
        }

        await Task.Delay(_checkInterval);
        await CheckForMatch();
    }

    public async Task AddPlayer(Player player)
    {
        _players.Add(player);
        await CheckForMatch();
    }

    public void RemovePlayer(Player player)
    {
        _players.Remove(player);
    }
}