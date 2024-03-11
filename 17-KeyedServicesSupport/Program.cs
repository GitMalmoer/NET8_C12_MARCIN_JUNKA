
using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<BigConsumer>();
builder.Services.AddSingleton<SmallConsumer>();

builder.Services.AddKeyedSingleton
    <IMyDictionary, BigDictionary>("big"); // keyed service
builder.Services.AddKeyedSingleton
    <IMyDictionary, SmallDictionary>("small");
builder.Services.AddKeyedSingleton
    <IMyDictionary, DifDictionary>("dif");

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MapGet("/big", (BigConsumer data) => data.GetData());
app.MapGet("/small", (SmallConsumer data) => data.GetData());


// KEYED
app.MapGet("/dif",
    ([FromServices] IServiceProvider keyedServiceProvider) =>
    keyedServiceProvider.
        GetRequiredKeyedService<IMyDictionary>("invalid").Get("data"));

app.Run();


class BigConsumer([FromKeyedServices("big")] IMyDictionary cache)
{
    public string? GetData() => cache.Get("data");
}

class SmallConsumer([FromKeyedServices("small")] IMyDictionary cache)
{
    public string? GetData() => cache.Get("data");
}


public interface IMyDictionary
{
    string Get(string key);
}