using Server.SignalR.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin()
            .SetIsOriginAllowed(origin => true);
    });
});

builder.Services.AddSignalR();

var app = builder.Build();

app.UseCors();
app.UseRouting();
app.MapHub<MyHub>("/hubs/myhub");

app.Run();
