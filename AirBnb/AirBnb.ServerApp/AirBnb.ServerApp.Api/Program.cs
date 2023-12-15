using AirBnb.Server.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);
await builder.ConfigureAsync();

var app = builder.Build();

app.UseCors();
app.UseStaticFiles();

await app.ConfigureAsync();
await app.RunAsync();
