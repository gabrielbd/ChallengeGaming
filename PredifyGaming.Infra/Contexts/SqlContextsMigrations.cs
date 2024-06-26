﻿using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace PredifyGaming.Infra.Contexts
{
    public class SqlContextsMigration : IDesignTimeDbContextFactory<SqlContexts>
    {
        public SqlContexts CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.Infra.json");
            config.AddJsonFile(path, false);

            var root = config.Build();
            var connectionString = root.GetSection("ConnectionStrings").GetSection("predifyConnection").Value;

            var builder = new DbContextOptionsBuilder<SqlContexts>();
            builder.UseSqlServer(connectionString);

            return new SqlContexts(builder.Options);
        }
    }
}
