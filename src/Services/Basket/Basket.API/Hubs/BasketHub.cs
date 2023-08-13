using Microsoft.AspNetCore.SignalR;

namespace Hermes.Basket.API.Hubs;

public class BasketHub : Hub
{
    public async Task SendMessage(string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", message);
    }
}