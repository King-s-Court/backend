using System.Text.RegularExpressions;
using Microsoft.AspNetCore.SignalR;

namespace backend;

public class ChessHub : Hub
{

    public async Task CreateGame()
    {
        var gameId = "1212312123";
        await Groups.AddToGroupAsync(Context.ConnectionId, gameId);
    }

    public async Task JoinGame(string gameId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, gameId);
    }

    public async Task LeaveGame(string gameId)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, gameId);
    }
    
    public async Task SendMove(string gameId, string move)
    {
        await Clients.OthersInGroup(gameId).SendAsync("ReceiveMove", move);
    }
}