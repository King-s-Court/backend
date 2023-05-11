using System.Text.RegularExpressions;
using Microsoft.AspNetCore.SignalR;
using common.Models;

namespace logic;

public class ChessHub : Hub
{

    private readonly QueueManager _queueManager;
    
    public ChessHub(QueueManager queueManager) {
        _queueManager = queueManager;
    }

    public async Task JoinQueue(GameModeEnum gameModeType, int timeLimit, int timeIncrement)
    {
        var player = new Player {
            QueueId = Context.ConnectionId,
            GameMode = new GameMode {
                GameModeType = gameModeType,
                TimeLimit = timeLimit,
                TimeIncrement = timeIncrement
            }
        };

        await _queueManager.AddPlayer(player);
    }

    public void LeaveQueue()
    {
        var player = new Player {
            QueueId = Context.ConnectionId
        };

        _queueManager.RemovePlayer(player);
    }
}