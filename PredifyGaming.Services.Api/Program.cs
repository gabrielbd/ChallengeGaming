using PredifyGaming.CrossCuting;
using PredifyGaming.Services.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

DependencyInjector.Register(builder.Services);
SetupIOC.AddEntityFrameworkServices(builder);
SetupIOC.AddMediatRServices(builder);
SetupIOC.AddAutoMapperServicess(builder);
SetupIOC.AddMongoDBServices(builder);

var app = builder.Build();


 app.UseSwagger();
 app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API-Prediffy-Gaming v1"));


app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program{ }