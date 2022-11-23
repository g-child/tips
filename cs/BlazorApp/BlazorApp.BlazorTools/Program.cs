using BlazorApp.BlazorTools.Data;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<CosmosDbService>();

AddCosmosDbService(builder.Services);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();


void AddCosmosDbService(IServiceCollection services)
{
    services.TryAddSingleton<CosmosDbService>();
    services.TryAddSingleton(_ => new CosmosClientBuilder("AccountEndpoint=https://cosmosdb-shared-jpeast.documents.azure.com:443/;AccountKey=zluEPYJOjorkLnVe5TmtwWcUN3Ci55w6tgnJKj4aA6QZD1invTr3DAZ2yvu6EhGuWU5DSGSxHNM2ACDbyepfTQ==;").WithConnectionModeDirect().Build());
}
