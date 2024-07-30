﻿using Microsoft.AspNetCore.SignalR;

namespace Server.SignalR.Hubs;

public class MyHub : Hub
{
    public async Task SendMessageAsync(string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", message);
    }
}
