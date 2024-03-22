using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PredifyGaming.Domain.Entities;
using PredifyGaming.Infra.Mappings;


namespace PredifyGaming.Infra.Contexts
{
    public class SqlContexts : DbContext
    {


        public SqlContexts(DbContextOptions<SqlContexts> dbContextOptions)
       : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GamesMapping());
            modelBuilder.ApplyConfiguration(new PlayersMapping());
            modelBuilder.ApplyConfiguration(new PlaysResultMapping());


        }
        public DbSet<Games> Games { get; set; }
        public DbSet<Players> Players { get; set; }
        public DbSet<PlaysResult> PlaysResult { get; set; }


    }
}
