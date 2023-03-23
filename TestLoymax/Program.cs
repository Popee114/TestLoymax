using Microsoft.EntityFrameworkCore;
using TestLoymax.BuildExtensions;
using TestLoymax.Configs;
using TestLoymax.Core.Contexts;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddDbContext<LoymaxContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString(nameof(LoymaxContext))));

builder.Services.RegistrationScopes();
builder.Services.RegistrationTransients();

builder.Services
    .Configure<ConnectionStrings>(configuration.GetSection(key: nameof(ConnectionStrings)));

builder.Services.AddDbContext<LoymaxContext>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();