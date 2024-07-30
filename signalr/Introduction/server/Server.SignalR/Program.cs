using Server.SignalR.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

var app = builder.Build();

app.MapHub<MyHub>("/hubs/myhub");

app.Run();
