using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Caching.Distributed.Redis.Common.Extensions;
using Caching.Distributed.Redis.OpenApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1);
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
    // options.ApiVersionReader = ApiVersionReader.Combine(
    //     new UrlSegmentApiVersionReader(),
    //     new HeaderApiVersionReader("X-ApiVersion"));
}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'V"; // V: Wildcard actual api version
    options.SubstituteApiVersionInUrl = true;
});

builder.Services.ConfigureOptions<ConfigureSwaggerGenOptions>();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost:6379";
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddModules();

var app = builder.Build();

app.UseModules();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        IReadOnlyList<ApiVersionDescription> descriptions = app.DescribeApiVersions();

        foreach (ApiVersionDescription description in descriptions)
        {
            string url = $"/swagger/{description.GroupName}/swagger.json";
            string name = description.GroupName.ToUpperInvariant();
            
            options.SwaggerEndpoint(url, name);
        }
    });
}

app.UseHttpsRedirection();

app.Run();