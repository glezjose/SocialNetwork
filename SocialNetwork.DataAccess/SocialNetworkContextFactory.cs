using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SocialNetwork.DataAccess.Context;
using System.Reflection;

namespace SocialNetwork.DataAccess
{
    public class SocialNetworkContextFactory : IDesignTimeDbContextFactory<SocialNetworkContext>
    {
        public SocialNetworkContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SocialNetworkContext>();
            builder.UseSqlServer("Server=BOT-JGONZALEZA;Database=SocialNetworkDB;Trusted_Connection=True;",
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(SocialNetworkContext).GetTypeInfo().Assembly.GetName().Name));


            return new SocialNetworkContext(builder.Options);
        }
    }
}
