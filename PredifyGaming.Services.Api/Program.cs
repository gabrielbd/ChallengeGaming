using PredifyGaming.CrossCuting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

DependencyInjector.Register(builder.Services);
SetupIOC.AddEntityFrameworkServices(builder);
SetupIOC.AddAutoMapperServicess(builder);
SetupIOC.AddMongoDBServices(builder);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program{ }