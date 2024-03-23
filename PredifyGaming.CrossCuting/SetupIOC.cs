using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PredifyGaming.Infra.Contexts;
using PredifyGaming.Infra.Logs.Contexts;
using PredifyGaming.Infra.Logs.Interfaces;
using PredifyGaming.Infra.Logs.Persistence;
using PredifyGaming.Infra.Logs.Settings;

namespace PredifyGaming.CrossCuting
{
    public static class SetupIOC
    {
        public static void AddEntityFrameworkServices(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("predifyConnection");

            builder.Services.AddDbContext<SqlContexts>(options => options.UseSqlServer(connectionString));
        }

        public static void AddAutoMapperServicess(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        public static void AddMongoDBServices(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDBPredify"));

            builder.Services.AddSingleton<MongoDBContext>();
            builder.Services.AddTransient<ILogPlaysResultPersistence, LogPlaysResultPersistence>();

        }
    }
}
