using Kredek.Api.Core;
using Kredek.Api.Core.Features.Examples;
using Kredek.Api.Core.Features.Drives;
using Kredek.Api.Infrastructure;
using Kredek.Api.Persistance;
using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCore(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddPersistance(builder.Configuration);

var app = builder.Build();

app.MapExampleEndpoints();
app.MapDriveEndpoints();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
