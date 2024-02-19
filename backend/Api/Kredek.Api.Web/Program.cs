using Kredek.Api.Core;
using Kredek.Api.Core.Features.Examples;
using Kredek.Api.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCore(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.MapExampleEndpoints();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
