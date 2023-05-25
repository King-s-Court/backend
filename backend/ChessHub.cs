using System.Text.RegularExpressions;
using Microsoft.AspNetCore.SignalR;
using common.Models;

namespace logic;

public class ChessHub : Hub
{

    private readonly QueueManager _queueManager;
    private readonly MoveGenerator _moveGenerator;
    
    public ChessHub(QueueManager queueManager, MoveGenerator moveGenerator) {
        _queueManager = queueManager;
        _moveGenerator = moveGenerator;
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

    public async Task JoinGame(string gameId)
    {
        Console.WriteLine(gameId);
        await Groups.AddToGroupAsync(Context.ConnectionId, gameId);
        await Clients.Group(gameId).SendAsync("PlayerJoined", Context.ConnectionId);
    }

    public async Task SendMove(int startRank, int startFile, int targetRank, int targetFile, string gameId)
    {
        // Process move that was made
        
        // Send back move of the opponent
        var newFen = _moveGenerator.GenerateMove(startRank, startFile, targetRank, targetFile);
        
        await Clients.Group(gameId).SendAsync("ReceiveMove", newFen);
    }

}